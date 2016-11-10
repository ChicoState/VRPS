//This software encodes a video file to PPM image files.
//Original Source : http://dranger.com/ffmpeg/tutorial01.html
//Modified by Fadi Yousif

#include "VidtoJPEG.h"

AVFrame *FF;
Image_struct *pt = new Image_struct;

uint8_t bytes[11520]; // 11520 * 2048 = 23592960


Shared_API int DecoderFunction(const char* FilePath) {

	av_register_all(); //Register all the codecs, parsers and bitstream filters which were enabled at configuration time.
	AVFormatContext *pFormatCtx = NULL; //Format I/O context 

	// open the file and store the file formate in the AVFormatContext struxture
	if (avformat_open_input(&pFormatCtx, FilePath, NULL, 0) != 0) { // replaces argv[1] with name
			return -3;
	}

	// Read packets of a media file to get stream information, return >= 0 if OKAY.
	// store the stream info into the pFormatCtx->streams
	if (avformat_find_stream_info(pFormatCtx, NULL) < 0) {
		printf("Couldn't find stream information\n");
		avformat_close_input(&pFormatCtx); //release AVFormatContext memory
		return -1;
	}

	 //Dump information about file onto standard error
	 //printf("Information about file\n");
	 //av_dump_format(pFormatCtx, 0, name, 0); // replaces argv[1] with name
	 //printf("_____________________________________________________________\n");

	 //printf("pFormatCtx->nb_streams = : %d\n", pFormatCtx->nb_streams);
	 //printf("pFormatCtx->streams[0] = : %s\n", av_get_media_type_string(pFormatCtx->streams[0]->codec->codec_type));
	 //printf("pFormatCtx->streams[1] = : %s\n", av_get_media_type_string(pFormatCtx->streams[1]->codec->codec_type));

	// now we find the video stream inside the stream info
	 int VideoStream = -1;

	 int i;
	 for (i = 0; i < (int)pFormatCtx->nb_streams; i++) {
		 if (pFormatCtx->streams[i]->codec->codec_type == AVMEDIA_TYPE_VIDEO) { // stream[0] == video stream
			 VideoStream = i;
			 break;
		 }
	 }

	 if (VideoStream == -1) { // if video stream is not found insides the nb_streams
		 printf("Didnt find the video stream\n");
		 avformat_close_input(&pFormatCtx); //release AVFormatContext memory
		 return -1;
	 }

	 AVCodecContext *pCodecCtxOrig = NULL;
	 AVCodecContext *pCodecCtxCopy = NULL;
	 // Get a pointer to the codec context for the video stream
	 // the codec is what the stream uses for decoding/encoding its data packets
	 pCodecCtxOrig = pFormatCtx->streams[VideoStream]->codec;

	 //find and open the codec
	 AVCodec *pCodec = NULL;

	 //find the decoder for the video stream
	 //printf("pCodecCtxOrig->codec_id = : %s\n", avcodec_get_name(pCodecCtxOrig->codec_id)); //codec name == mpeg4
	 pCodec = avcodec_find_decoder(pCodecCtxOrig->codec_id);
	 if (pCodec == NULL) {
		 printf("codec not found (unsupprted codec)\n");
		 avformat_close_input(&pFormatCtx); //release AVFormatContext memory
		 return -1; 
	 }

	 /* Allocates an AVCodecContext in memory and set its fields to default values.*/
	 pCodecCtxCopy = avcodec_alloc_context3(pCodec);
	
	 /*Copy the codec settings of the source AVCodecContext (pCodecCtxOrig) into the destination
	   AVCodecContext (pCodecCtxCopy).The resulting destination codec context will be
	   unopened, i.e.you are required to call avcodec_open2() before you
	   can use this AVCodecContext to decode / encode video / audio data.*/
	 if (avcodec_copy_context(pCodecCtxCopy, pCodecCtxOrig) != 0) {
		 printf("Couldn't copy codec context");
		 return -1;
	 }

	 AVDictionary *optionsDict = NULL;
	 // Open codec
	 if (avcodec_open2(pCodecCtxCopy, pCodec, &optionsDict) < 0) {
		 printf("Could not open codec.\n");
		 return -1;
	 }
	
	 /*----------------------------------------------------------------------------
	 *      			Setting up locations to store the data
	 *---------------------------------------------------------------------------*/
	 AVFrame *pFrame = NULL; // Native format of the frame is stored here
	 AVFrame *pFrameRGB = NULL;// The RGB format after conversion from native format is stored here.

	 pFrame = av_frame_alloc(); // allocated memmory for the frame.

	// allocate a frame for the converted type of frame
	 pFrameRGB = av_frame_alloc();
	 if (pFrameRGB == NULL) {
		 printf("Allocation failed.\n");
		 return -1;
	 }

	 // Allocating space to put the raw data 
	 uint8_t *buffer = NULL;
	 int numBytes;

	 /* avpicture_get_size Calculates the size in bytes that a picture of the given width and height
	    would occupy if stored in the given picture format.*/
	 numBytes = avpicture_get_size(AV_PIX_FMT_RGB24, pCodecCtxCopy->width, pCodecCtxCopy->height);
	 if (numBytes < 0) {
		 printf("Failed to computed picture buffer size.\n");
		 return -1;
	 }

	 // Determine required buffer size and allocate buffer
	 /* Allocate a block of size bytes with alignment suitable for all memory accesses*/
	 buffer = (uint8_t *)av_malloc(numBytes * sizeof(uint8_t));

	 //Assign appropriate parts of buffer to image planes in pFrameRGB
	 avpicture_fill((AVPicture *)pFrameRGB, buffer, AV_PIX_FMT_RGB24, pCodecCtxCopy->width, pCodecCtxCopy->height);

	 /*----------------------------------------------------------------------------
	 *      					Reading the Data
	 *---------------------------------------------------------------------------*/
	 /*Read through the entire video stream one packet at a time. Decode the packet into
	   frame and once the frame is complete, we will convert it and save it.
	 */
	 struct SwsContext *sws_ctx = NULL;

	 // initialize SWS context for software scaling
	 //* @deprecated Use sws_getCachedContext() instead.
	 sws_ctx = sws_getContext(pCodecCtxCopy->width, //the width of the source image
		 pCodecCtxCopy->height, //the height of the source image
		 pCodecCtxCopy->pix_fmt, //the source image format
		 pCodecCtxCopy->width, //the width of the destination image
		 pCodecCtxCopy->height, //the height of the destination image
		 AV_PIX_FMT_RGB24, //the destination image format
		 SWS_FAST_BILINEAR, //flags specify which algorithm and options to use for rescaling
		 NULL, //source filter
		 NULL, //distination filter
		 NULL // param
	 );

	 AVPacket packet;
	 int frameFinished;
	 i = 0;

	 while (av_read_frame(pFormatCtx, &packet) >= 0) { //Return the next frame of a stream.
		 // Is this a packet from the video stream?
		 if (packet.stream_index == VideoStream) {
			 // Decode the video frame of size avpkt->size from avpkt->data into raw(Native Formate) picture.
			 // the pFrame will be of size packet
			 avcodec_decode_video2(pCodecCtxCopy, pFrame, &frameFinished, &packet);
			 //packet.buf;
			 //pFrame->buf;

			 /* Did we get a video frame?
				frameFinished on return contains 1 or 0 .
				If it is 1 it means the whole frame was decoded .
				If it is 0 it means that the frame was not decoded*/
			 if (frameFinished) {
				 // Convert the image from its native format to RGB
				 sws_scale(sws_ctx, (uint8_t const * const *)pFrame->data, pFrame->linesize, 
							0, pCodecCtxCopy->height,
							pFrameRGB->data, pFrameRGB->linesize);

				 // Save the first 10 frames to disk
				 //printf("Number of frames = %d\n", pCodecCtxCopy->frame_number);
				 if (++i <= 1) {
					 //TransferFrame(pFrameRGB, pCodecCtxCopy->width, pCodecCtxCopy->height, i);
					 framesfrom_C_2_Unity(pFrameRGB, pCodecCtxCopy->width, pCodecCtxCopy->height);
					 //StoreFrame(pFrameRGB, pCodecCtxCopy->width, pCodecCtxCopy->height);
					 FF = pFrameRGB;
				 }
			 }
		 }

		 // Free the packet that was allocated by av_read_frame
		 av_free_packet(&packet);
	 }

	 // Free the RGB image
	 av_free(buffer);
	 av_frame_free(&pFrameRGB);

	 // Free the YUV frame
	 av_frame_free(&pFrame);

	 // Close the codecs
	 avcodec_close(pCodecCtxCopy);
	 avcodec_close(pCodecCtxOrig);

	 // Close the video file
	 avformat_close_input(&pFormatCtx);

	return -90; // return 0 on success
}

void TransferFrame(AVFrame *pFrameRGB, int width, int height, int iFrame) {
	FILE *pFile;
	char szFilename[32];
	int  y;

	// Open file
	sprintf_s(szFilename, "frame%d.ppm", iFrame);

	fopen_s(&pFile, szFilename, "wb");
	//if (pFile == NULL)
	//	return;

	// Write header
	fprintf(pFile, "P6\n%d %d\n255\n", width, height);

	//printf("data0 contains = %d\n", pFrameRGB->data[0]);
	//printf("linesize0 contains = %d\n", pFrameRGB->linesize[0]);
	//printf("width = %d, height %d\n", width, height);

	// width*3 = 11520 = linesize[0] = #bytes of data for each horizontal line
	// 1 = size in bytes of each element of linesize.

	// Write pixel data
	for (y = 0; y<height; y++)
		fwrite(pFrameRGB->data[0] + y*pFrameRGB->linesize[0], 1, pFrameRGB->linesize[0], pFile);

	// Close file
	fclose(pFile);
}

void StoreFrame(AVFrame *pFrameRGB, int width, int height) {
	int x;
	int linesize = pFrameRGB->linesize[0]; // the number of bytes in one horizontal line of the pic.

	// Write pixel data to buffer
	//for (i = 0; i < height; i++) {
	for (x = 0; x < (linesize); x++) {
		bytes[x] = *(pFrameRGB->data[0] + x); // bytes is a global array
	}
	//for (x = i*linesize; x < (linesize + i*linesize); x++) {
	//	bytes[x] = *(pFrame->data[0] + x);
	//}
	//pFrame->data[0] + i*linesize; // advances the data pointer to the next line
	//}


	//for (i = 0; i < 100; i++) {
	//	printf("array[%i] contains byte = %#04x\n", i, (bytes[i]));
	//}
}

Shared_API uint8_t *linePt() {
	uint8_t *pt = bytes;
	return pt;
}

Shared_API void fillarraydata(uint8_t *buf)
{
	//*(buf) = 6;
	//*(buf+1) = 4;
	//*(buf+2) = *(FF->data[0]+1);
	//*(buf+3) = 2;
	//*(buf+4) = 1;

	int i, x;
	int linesize = pt->Converted_Frame->linesize[0]; // the number of bytes in one horizontal line of the pic = 11520 bytes.

	for (x = 0; x < linesize; x++) {
		*(buf + x) = *(pt->Converted_Frame->data[0] + x);
	}

	//// Write pixel data to buffer
	//for (i = 0; i < pt->Img_height; i++) {
	//	for (x = 0; x < linesize; x++) {
	//		*(buf + (i*linesize) + x) = 
	//			*(pt->Converted_Frame->data[0] + (i*linesize) + x);
	//	}
	//	//pt->Converted_Frame->data[0] += (i*linesize); // advances the data pointer to the next line
	//}
	
}


void framesfrom_C_2_Unity(AVFrame *pFrameRGB, int width, int height) {
	pt->Converted_Frame = pFrameRGB;
	pt->Img_width = width;
	pt->Img_height = height;
}

Shared_API AVFrame *FrameData() {
	return pt->Converted_Frame; //RGB frame
}

Shared_API int FrameWidth() {
	return pt->Img_width;
}
Shared_API int FrameHeight() {
	return pt->Img_height;
}

Shared_API void CleanMemory() {
	//delete pt->Converted_Frame;
	delete pt;
}



