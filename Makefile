UNAME = $(shell uname)

ifeq ($(UNAME), Darwin)
	LIBNAME = libstb_vorbis.dylib
	LIBNAMEAPI = libstb_vorbis.0.dylib
	LIBFLAG = -install_name
else
	LIBNAME = libstb_vorbis.so
	LIBNAMEAPI = libstb_vorbis.so.0
	LIBFLAG = -soname
endif

all: libstb_vorbis STBVorbis.dll

libstb_vorbis: stb_vorbis.c
	$(CC) -fPIC -shared -Wl,$(LIBFLAG),$(LIBNAME) -o $(LIBNAMEAPI) stb_vorbis.c
	ln -s $(LIBNAMEAPI) $(LIBNAME)

STBVorbis.dll: STBVorbis.cs
	dmcs -out:STBVorbis.dll -target:library	STBVorbis.cs

clean:
	rm -f $(LIBNAMEAPI) $(LIBNAME) STBVorbis.dll
