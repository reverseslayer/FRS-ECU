<h1 align="center">FRSECU</h1>

Welcome to the FRSECU reverse engineering project of the frs/gt86/brz twins computer. The goal of the project is to convert the ECU back into a C language so that it can be modified freely to work with whatever suits anyones needs. Feel free to support the project.

## Progress

The ECU stock rom has been converted from binary to assembly.
The gcc cross compiler has been created
Alot of relevent data has been collected

## To Do

Weed out the tables from the rom so we can work with the code alone</br>
Setup the boot sequences in the code</br>
Map the input out output pins in memory</br>
Set the location specific variables in the linker and in C</br>
Convert the assembly functions to a C form</br>

I have been thinking and feel it would be easier to not static link all of the tables to their original places. This will allow the compiler to use the minimal space in the ecu rom more efficiently but will also break any associations with RomRaider. So therefor the tables within the code need to be easily accessable and understanable so someone tuning their car can edit the tables and then compile to flash. Some data would have to be static of course such as the ECU ID. 

## Disclaimer

The goal of this project is to experiment, research, and educate on the topic
of reverse engineering. All information is obtained via reverse engineering of
legally purchased devices and information made public on the internet
(you'd be surprised what's indexed on Google...).

## Building

The only tools you will need is windows itself. The compiler has been included because it was hard to find.
[GCC-License](https://gcc.gnu.org/onlinedocs/libstdc++/manual/license.html)

Fixes and optimizations are always welcome (please!)


## Documentation

You can find the compiler documentation within the Docs Folder

## About The ECU

[CPU Archetectrue Reference](https://www.renesas.com/us/en/doc/products/mpumcu/001/rej09b0051_sh2a.pdf)</br>
[Newer Architecture Version 'Easier to read'](https://antime.kapsi.fi/sega/files/h12p0.pdf)

Key Features

	    SH2A-FPU intelligent RISC
        Up to 200MHz, 3.3V/5.0V
        SH2A-FPU instruction (112 instructions)
    On-chip memory
        ROM: 1.25MB to 2MB
        RAM: 64KB to 96KB
    Peripherals
        Timer: CMT:2ch + ATU-III
        A/D converter: 12bits, 32ch (23+9)
        Serial: 3ch
        DMAC: 8ch
        A-DMAC: 58ch
        RCAN-TL1: 2ch
        RSPI: 2ch
        I/O port: 112 (Max)
        INTC (Interrupt controller): 5 external interrupt pins
    Model
        R5F72531DKFPU
    Pin Count
        176
    Package Type
        LFQFP
    Memory
        Program memory
            1280 KB Flash memory
        RAM
            64 KB
        Data Flash
            32 KB
        Cache Memory Remark
            ROM cache: instruction cache (full associative, 8 lines, 16 bytes/line), data cache (full associative, 4 lines, 16 bytes/line); line size is 16 bytes/line
    CPU
        CPU
            SH2A-FPU (32-bit)
        Max. Frequency
            160 MHz
        PLL
            YES
        Power-On Reset
            YES
        Floating Point Unit
            YES
        DMA Remarks
            DMAC x 8 ch, A-DMAC x 58 ch
        External Interrupt Pins
            5
        I/O Ports
            112
        Timers
            16-bit Timers
                30 ch
            32-bit Timers
                5 ch
            Watchdog Timers
                1 ch
            Other Timers
                24-bit timer x 73
            PWM Output
                20
    Analog
        A/D Converters
            12-bit x 32 ch
    Interfaces
        CAN
            2 ch
        CSIs
            3 ch
        SPIs
            2 ch
        UARTs
            3 ch
        Serial Interface Remarks
            SCI (CSI:3ch/UART:3ch), RSPI (SPI:2ch)
    Operating Conditions
        Operating Voltage
            4.5 to 5.5 V
        Power Supply
            VCC = PLLVCC = 3.3 V ±0.3 V, PVCC = AVCC = 5.0 V ±0.5 V, AVREFH = 4.5 V to AVCC, V = PLLV = AV = AVREFL = 0 V
        Operating Temperature
            -40 to 125 ℃ (Ambient Temperature)
