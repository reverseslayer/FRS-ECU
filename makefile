CSOURCES=$(shell find src/ -type f -name "*.c")

COBJ=$(patsubst %.c,%.o,$(CSOURCES))

Clear: Rom.bin
	rm -f *.bin
	rm -f src/*.o

Rom.bin: $(COBJ) $(AOBJ)
	GCC-Windows/bin/sh-elf-gcc -T src/linker.ld -o Rom.bin --target=sh2a-single -mhitachi -ffreestanding -O2 -nostdlib -lgcc $(COBJ)

%.o: %.cpp
	GCC-Windows/bins/sh-elf-gcc -c $< -o $@ -ffreestanding -O2 -Wall -Wextra -fno-exceptions -fno-rtti