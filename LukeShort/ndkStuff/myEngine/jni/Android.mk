LOCAL_PATH := $(call my-dir)

include $(CLEAR_VARS)

LOCAL_MODULE := IntReturn

CODE_PATH := ../Engine

LOCAL_C_INCLUDES := $(LOCAL_PATH)/$(CODE_PATH)/include

LOCAL_SRC_FILES := $(CODE_PATH)/src/engine.cpp

include $(BUILD_SHARED_LIBRARY)
