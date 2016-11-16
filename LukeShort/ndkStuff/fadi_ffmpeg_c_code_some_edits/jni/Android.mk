LOCAL_PATH := $(call my-dir)

#Have to include ea library as separate module
include $(CLEAR_VARS)
CODE_PATH := ../myPlugin
LOCAL_MODULE := avcodec-prebuilt
LOCAL_SRC_FILES := $(CODE_PATH)/src/libavcodec.so
include $(PREBUILT_SHARED_LIBRARY)

include $(CLEAR_VARS)
CODE_PATH := ../myPlugin
LOCAL_MODULE := avdevice-prebuilt
LOCAL_SRC_FILES := $(CODE_PATH)/src/libavdevice.so
include $(PREBUILT_SHARED_LIBRARY)

include $(CLEAR_VARS)
CODE_PATH := ../myPlugin
LOCAL_MODULE := avfilter-prebuilt
LOCAL_SRC_FILES := $(CODE_PATH)/src/libavfilter.so
include $(PREBUILT_SHARED_LIBRARY)

include $(CLEAR_VARS)
CODE_PATH := ../myPlugin
LOCAL_MODULE := avformat-prebuilt
LOCAL_SRC_FILES := $(CODE_PATH)/src/libavformat.so
include $(PREBUILT_SHARED_LIBRARY)

include $(CLEAR_VARS)
CODE_PATH := ../myPlugin
LOCAL_MODULE := avutil-prebuilt
LOCAL_SRC_FILES := $(CODE_PATH)/src/libavutil.so
include $(PREBUILT_SHARED_LIBRARY)

include $(CLEAR_VARS)
CODE_PATH := ../myPlugin
LOCAL_MODULE := postproc-prebuilt
LOCAL_SRC_FILES := $(CODE_PATH)/src/libpostproc.so
include $(PREBUILT_SHARED_LIBRARY)

include $(CLEAR_VARS)
CODE_PATH := ../myPlugin
LOCAL_MODULE := swresample-prebuilt
LOCAL_SRC_FILES := $(CODE_PATH)/src/libswresample.so
include $(PREBUILT_SHARED_LIBRARY)

include $(CLEAR_VARS)
CODE_PATH := ../myPlugin
LOCAL_MODULE := swscale-prebuilt
LOCAL_SRC_FILES := $(CODE_PATH)/src/libswscale.so
include $(PREBUILT_SHARED_LIBRARY)

include $(CLEAR_VARS)

LOCAL_MODULE := VideoPlugin

CODE_PATH := ../myPlugin

LOCAL_C_INCLUDES := $(LOCAL_PATH)/$(CODE_PATH)/include

LOCAL_SRC_FILES := $(CODE_PATH)/src/Video_to_JPEG.cpp
LOCAL_SHARED_LIBRARIES := avcodec-prebuilt \
	avdevice-prebuilt \
	avfilter-prebuilt \
	avformat-prebuilt \
	avutil-prebuilt \
	postproc-prebuilt \
	swresample-prebuilt \
	swscale-prebuilt
include $(BUILD_SHARED_LIBRARY)

