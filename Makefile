all: libstb_vorbis.so STBVorbis.dll

libstb_vorbis.so: stb_vorbis.c
	$(CC) -fPIC -shared -Wl,-soname,libstb_vorbis.so -o libstb_vorbis.so.0 stb_vorbis.c
	ln -s libstb_vorbis.so.0 libstb_vorbis.so

STBVorbis.dll: STBVorbis.cs
	dmcs -out:STBVorbis.dll -target:library	STBVorbis.cs

clean:
	rm -f libstb_vorbis.so.0 libstb_vorbis.so STBVorbis.dll
