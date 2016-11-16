//This program decodes a video stream into to a series of images in RGB24 format
//Original Source : http://dranger.com/ffmpeg/tutorial01.html
//Written and Modified by Fadi Yousif

#include "VidtoJPEG.h"

AVPacket packet;
int frameFinished;
uint32_t x;

AVFormatContext *pFormatCtx = NULL;		//Video File input context 
AVCodecContext  *pCodecCtxOrig = NULL;
AVCodecContext  *pCodecCtxCopy = NULL;
AVFrame			*pFrame = NULL;			// Native format of the frame is stored here
AVFrame			*pFrameRGB = NULL;		// The RGB format after conversion from native format is stored here.
uint8_t			*buffer = NULL;
struct SwsContext *sws_ctx = NULL;
int VideoStream = -1;

int testing = 9;

//Shared_API int DecoderFunction(const char* FilePath) {
int DecoderFunction(const char* FilePath) {

	av_register_all(); //Register all the codecs, parsers and bitstream filters which were enabled at configuration time.

	// open the file and store the file formate in the AVFormatContext struxture
	if (avformat_open_input(&pFormatCtx, FilePath, NULL, 0) != 0) { // replaces argv[1] with name
		return -1;
	}

	// Read packets of a media file to get stream information, return >= 0 if OKAY.
	// store the stream info into the pFormatCtx->streams
	if (avformat_find_stream_info(pFormatCtx, NULL) < 0) {
		avformat_close_input(&pFormatCtx); //release AVFormatContext memory
		return -2;
	}

	// now we find the video stream inside the stream info
	int i;
	for (i = 0; i < (int)pFormatCtx->nb_streams; i++) {
		if (pFormatCtx->streams[i]->codec->codec_type == AVMEDIA_TYPE_VIDEO) { // stream[0] == video stream
			VideoStream = i;
			break;
		}
	}

	if (VideoStream == -1) { // if video stream is not found insides the nb_streams
		avformat_close_input(&pFormatCtx); //release AVFormatContext memory
		return -3;
	}

	// Get a pointer to the codec context for the video stream
	// the codec is what the stream uses for decoding/encoding its data packets
	pCodecCtxOrig = pFormatCtx->streams[VideoStream]->codec;

	//find and open the codec
	AVCodec *pCodec = NULL;

	//find the decoder for the video stream
	//printf("pCodecCtxOrig->codec_id = : %s\n", avcodec_get_name(pCodecCtxOrig->codec_id)); //codec name == mpeg4
	pCodec = avcodec_find_decoder(pCodecCtxOrig->codec_id);
	if (pCodec == NULL) {
		avformat_close_input(&pFormatCtx); //release AVFormatContext memory
		return -4;
	}

	/* Allocates an AVCodecContext in memory and set its fields to default values.*/
	pCodecCtxCopy = avcodec_alloc_context3(pCodec);

	/*Copy the codec settings of the source AVCodecContext (pCodecCtxOrig) into the destination
	AVCodecContext (pCodecCtxCopy).The resulting destination codec context will be
	unopened, i.e.you are required to call avcodec_open2() before you
	can use this AVCodecContext to decode / encode video / audio data.*/
	if (avcodec_copy_context(pCodecCtxCopy, pCodecCtxOrig) != 0) {
		return -5;
	}

	//AVDictionary *optionsDict = NULL;
	// Open codec
	if (avcodec_open2(pCodecCtxCopy, pCodec, NULL) < 0) {
		return -6;
	}

	/*----------------------------------------------------------------------------
	*      			Setting up locations to store the data
	*---------------------------------------------------------------------------*/

	// allocated memmory for the frame.
	pFrame = av_frame_alloc(); 
	if (pFrame == NULL) {
		return -7;
	}

	// allocate a frame for the converted type of frame
	pFrameRGB = av_frame_alloc();
	if (pFrameRGB == NULL) {
		return -8;
	}

	// Allocating space to put the raw data 
	int numBytes;

	/* avpicture_get_size Calculates the size in bytes that a picture of the given width and height
	would occupy if stored in the given picture format.*/
	numBytes = avpicture_get_size(AV_PIX_FMT_RGB24, pCodecCtxCopy->width, pCodecCtxCopy->height);
	if (numBytes < 0) {
		return -9;
	}

	// Determine required buffer size and allocate buffer
	/* Allocate a block of size bytes with alignment suitable for all memory accesses*/
	buffer = (uint8_t *)av_malloc(numBytes * sizeof(uint8_t));

	//Assign appropriate parts of buffer to image planes in pFrameRGB
	avpicture_fill((AVPicture *)pFrameRGB, buffer, AV_PIX_FMT_RGB24, pCodecCtxCopy->width, pCodecCtxCopy->height);

	// initialize SWS context for software scaling
	//* @deprecated Use sws_getCachedContext() instead.
	sws_ctx = sws_getContext(pCodecCtxCopy->width, //the width of the source image
		pCodecCtxCopy->height, //the height of the source image
		pCodecCtxCopy->pix_fmt, //the source image format
		pCodecCtxCopy->width, //the width of the destination image
		pCodecCtxCopy->height, //the height of the destination image
		AV_PIX_FMT_RGB24, //the destination image format
		SWS_BILINEAR, //flags specify which algorithm and options to use for rescaling
		NULL, //source filter
		NULL, //distination filter
		NULL // param
	);

	return 10;
}


void StoreFrame(uint8_t *Array, uint32_t Total_Bytes, struct SwsContext *sws_ctx, AVCodecContext *pCodecCtxCopy, AVFormatContext *pFormatCtx,
	int VideoStream, AVFrame *pFrame, AVFrame *pFrameRGB)
{
	//This while loop makes sure that we have a video packet index = 0; which means a valid video frame to be decoded.
	while (av_read_frame(pFormatCtx, &packet) >= 0) { //Return the next frame of a stream.
		// Is this a packet from the video stream? Y? break and start decoding, N? free the packet and continue
		if (packet.stream_index == VideoStream) {
			// Decode the video frame of size avpkt->size from avpkt->data into raw(Native Formate) picture.
			// the pFrame will be of size packet
			avcodec_decode_video2(pCodecCtxCopy, pFrame, &frameFinished, &packet);
			//Did we get a video frame?
			if (frameFinished) {
				// Convert the image from its native format to RGB24
				sws_scale(sws_ctx, (uint8_t const * const *)pFrame->data, pFrame->linesize,
					0, pCodecCtxCopy->height,
					pFrameRGB->data, pFrameRGB->linesize);

				/*4-Fill the array that is passed from C# with image data
				The number of bytes for one frame 11520 * 2048 = 23592960 bytes for each frame.
				Writes pixel data (One Full Image) to the array*/
				for (x = 0; x < Total_Bytes; x++) {
					*(Array + x) = *(pFrameRGB->data[0] + x); // bytes is a global array
				}
			}
			av_free_packet(&packet);
			break;
		}
		// free the packet that was allocated by av_read_frame when the streaming index != Videostream 
		av_free_packet(&packet);
	}//while

	//This will make the video loop
	if (av_read_frame(pFormatCtx, &packet) < 0) {
		av_seek_frame(pFormatCtx, 0, 0, 0);// go back to the first frame.
	}
}//StoreFrame


void FreeDataAllocations(uint8_t *Imgbuf, AVFrame *pFrameRGB, AVFrame *pFrame, AVCodecContext *pCodecCtxCopy,
	AVCodecContext *pCodecCtxOrig, AVFormatContext *pFormatCtx)
{
	// Free the RGB image
	av_free(Imgbuf);

	av_frame_free(&pFrameRGB);

	// Free the YUV frame
	av_frame_free(&pFrame);

	// Close the codecs
	avcodec_close(pCodecCtxCopy);
	avcodec_close(pCodecCtxOrig);

	// Close the video file
	avformat_close_input(&pFormatCtx);
}

/*Shared_API void SendArray(uint8_t *CSBuf, uint32_t Total_Bytes_Per_Frame)
{
	// this function decodes each frame and stores it into the specefied array.
	StoreFrame(CSBuf, Total_Bytes_Per_Frame, sws_ctx, pCodecCtxCopy, pFormatCtx, VideoStream, pFrame, pFrameRGB);
}

Shared_API int ReturnInt() {
	return testing;
}

Shared_API void CleanMemory() {
	FreeDataAllocations(buffer, pFrameRGB, pFrame, pCodecCtxCopy, pCodecCtxOrig, pFormatCtx);
}*/

//fxns that are being extern C'd...
void SendArray(uint8_t *CSBuf, uint32_t Total_Bytes_Per_Frame)
{
	// this function decodes each frame and stores it into the specefied array.
	StoreFrame(CSBuf, Total_Bytes_Per_Frame, sws_ctx, pCodecCtxCopy, pFormatCtx, VideoStream, pFrame, pFrameRGB);
}

int ReturnInt() {
	return testing;
}

void CleanMemory() {
	FreeDataAllocations(buffer, pFrameRGB, pFrame, pCodecCtxCopy, pCodecCtxOrig, pFormatCtx);
}
