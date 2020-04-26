#define bool _Bool;

#define R0 0x01
#define R1 0x02
#define R2 0x03
#define R3 0x04
#define R4 0x05
#define R5 0x06
#define R6 0x07
#define R7 0x08
#define R8 0x09
#define R9 0x0a
#define R10 0x0b
#define R11 0x0c
#define R12 0x0d
#define R13 0x0e
#define R14 0x0f

typedef struct StatusRegister_t{ // 32bit status register
	bool T;
	bool S;

} SR;

typedef struct GlobalBaseRegister_t{ // 32bit status register
	uint32_t dataSegment;
	uint32_t edi, esi, ebp, esp, ebx, edx, ecx, eax;
	uint32_t intNum, errCode;
	uint32_t eip, cs, eflags, useresp, ss;
} GBR;

typedef struct VectorBaseRegister_t{ // 32bit status register
	uint32_t dataSegment;
	uint32_t edi, esi, ebp, esp, ebx, edx, ecx, eax;
	uint32_t intNum, errCode;
	uint32_t eip, cs, eflags, useresp, ss;
} VBR;

typedef struct JumpTableBaseRegister_t{ // 32bit status register
	uint32_t dataSegment;
	uint32_t edi, esi, ebp, esp, ebx, edx, ecx, eax;
	uint32_t intNum, errCode;
	uint32_t eip, cs, eflags, useresp, ss;
} TBR;

int main(void){
	int ret;
	ret = printf("Hello World!\r\n");
	return ret;
}