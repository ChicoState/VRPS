#pragma once

//Written and Modified by Fadi Yousif

#include <stdlib.h>
#include <machine/_types.h>//req'd for __va_list and other "__" types
#include <stdio.h>
#include <string.h>

/*#define Shared_API __declspec(dllexport) //dllexport attribute allows export functions/data from dll

#define __STDC_CONSTANT_MACROS

#ifdef _WIN32
//Windows
extern "C"
{
#include "libavcodec/avcodec.h"
#include "libavformat/avformat.h"
#include "libswscale/swscale.h"
};
#else
//Linux...
#ifdef __cplusplus
extern "C"
{
#endif

#include <libavcodec/avcodec.h>
#include <libavformat/avformat.h>
#include <libswscale/swscale.h>

#ifdef __cplusplus
};
#endif
#endif*/

//no idea why these need to be extern C'd but Fadi did it, so whatever
//Okay they're actually needed when we have .c and .cpp files b/c library headers won't include an extern "C" when compiled as C++
#ifdef __cplusplus
extern "C"
{
#endif
#include "libavcodec/avcodec.h"
#include "libavformat/avformat.h"
#include "libswscale/swscale.h"
#ifdef __cplusplus
};
#endif

//Internal functions
void StoreFrame(uint8_t *Array, uint32_t Total_Bytes, struct SwsContext *sws_ctx, AVCodecContext *pCodecCtxCopy,
					AVFormatContext *pFormatCtx,
					int VideoStream, AVFrame *pFrame, AVFrame *pFrameRGB);

void FreeDataAllocations(uint8_t *Imgbuf, AVFrame *pFrameRGB, AVFrame *pFrame, 
							AVCodecContext *pCodecCtxCopy,AVCodecContext *pCodecCtxOrig, 
							AVFormatContext *pFormatCtx);

//extern "C" is meant to be recognized by a C++ compiler and to notify the compiler that the noted function is (or to be) compiled in C style.
/*extern "C" { 
	Shared_API int DecoderFunction(const char* FilePath);

	Shared_API int ReturnInt();

	Shared_API void SendArray(uint8_t *CSBuf, uint32_t Total_Bytes_Per_Frame); // maybe reduce the size of the int to 8 bits later

	Shared_API void CleanMemory();
}*/
extern "C" { 
	int DecoderFunction(const char* FilePath);
	int ReturnInt();
	void SendArray(uint8_t *CSBuf, uint32_t Total_Bytes_Per_Frame); // maybe reduce the size of the int to 8 bits later
	void CleanMemory();
}

