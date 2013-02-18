/*
 * STBVorbis-CS: A stb_vorbis wrapper for .NET
 * 
 * Copyright (c) 2013 David Gow <david@ingeniumdigital.com>
 * 
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from
 * the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 * claim that you wrote the original software. If you use this software in a
 * product, an acknowledgment in the product documentation would be
 * appreciated but is not required.
 * 
 * 2. Altered source versions must be plainly marked as such, and must not be
 * misrepresented as being the original software.
 * 
 * 3. This notice may not be removed or altered from any source distribution.
 * 
 */

using System;
using System.Runtime.InteropServices;

public class STBVorbis
{
	const string _dll_name = "stb_vorbis.dll";

	[StructLayout(LayoutKind.Sequential)]
	public struct AllocBuffer
	{
		public IntPtr buffer;
		public int length_in_bytes;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct Info
	{
		public uint sample_rate;
		public int channels;
		public uint setup_memory_required;
		public uint setup_temp_memory_required;
		public int max_frame_size;
	}

	[DllImport(_dll_name, EntryPoint = "stb_vorbis_get_info")]
	extern public static Info GetInfo(IntPtr f);

	[DllImport(_dll_name, EntryPoint = "stb_vorbis_get_error")]
	extern public static int GetError(IntPtr f);

	[DllImport(_dll_name, EntryPoint = "stb_vorbis_close")]
	extern public static void Close(IntPtr f);

	[DllImport(_dll_name, EntryPoint = "stb_vorbis_get_sample_offset")]
	extern public static int GetSampleOffset(IntPtr f);

	[DllImport(_dll_name, EntryPoint = "stb_vorbis_get_file_offset")]
	extern public static uint GetFileOffset(IntPtr f);

	//TODO: Pushdata API if anyone cares.

	[DllImport(_dll_name, EntryPoint = "stb_vorbis_decode_filename")]
	extern public static int DecodeFilename(string filename, out int channels, out IntPtr output);

	[DllImport(_dll_name, EntryPoint = "stb_vorbis_decode_memory")]
	extern public static int DecodeMemory(IntPtr memory, out int channels, out IntPtr output);

	[DllImport(_dll_name, EntryPoint = "stb_vorbis_open_memory")]
	extern public static IntPtr OpenMemory(IntPtr data, int len, out int error, IntPtr alloc_buffer);

	[DllImport(_dll_name, EntryPoint = "stb_vorbis_open_filename")]
	extern public static IntPtr OpenFilename(string filename, out int error, IntPtr alloc_buffer);

	[DllImport(_dll_name, EntryPoint = "stb_vorbis_seek_start")]
	extern public static void SeekStart(IntPtr f);

	[DllImport(_dll_name, EntryPoint = "stb_vorbis_stream_length_in_samples")]
	extern public static uint StreamLengthInSamples(IntPtr f);

	[DllImport(_dll_name, EntryPoint = "stb_vorbis_stream_length_in_seconds")]
	extern public static float StreamLengthInSeconds(IntPtr f);

	//TODO: Implement all of the other get data functions.

	[DllImport(_dll_name, EntryPoint = "stb_vorbis_get_frame_short_interleaved")]
	extern public static int GetFrameShortInterleaved(IntPtr f, int num_channels, short[] buffer, int num_shorts);

	[DllImport(_dll_name, EntryPoint = "stb_vorbis_get_samples_short_interleaved")]
	extern public static int GetSamplesShortInterleaved(IntPtr f, int num_channels, short[] buffer, int num_shorts);

	[DllImport(_dll_name, EntryPoint = "stb_vorbis_get_samples_float_interleaved")]
	extern public static int GetSamplesShortInterleaved(IntPtr f, int num_channels, float[] buffer, int num_shorts);
}
