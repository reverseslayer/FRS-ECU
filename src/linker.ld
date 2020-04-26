ENTRY(_start)

MEMORY
{
	а ram (rw) : o = 0x0400000, l =512k

	а rom (rx) : o = 0x0000000, l =512k
}

SECTIONS
{
	.tors:
	{
		ааа __CTOR_LIST__ =.;
		ааа LONG((__CTOR_END__ -__CTOR_LIST__) / 4 - 2)
		ааа ___ctors = .;
		ааа*(.ctors)
		ааа ___ctors_end = .;
		аааLONG(0)
		аа __CTOR_END__ =.;
		ааа __DTOR_LIST__ =.;
		аа LONG((__DTOR_END__ -__DTOR_LIST__) / 4 - 2)
		ааа ___dtors = .;
		аа *(.dtors)
		ааа ___dtors_end = .;
		аааLONG(0)
		ааа __DTOR_END__ =.;
	} > rom

	.my_data_section 0x0400 :
	{
		/* */
		_my_data_section = .;
		*(.my_data_section)
		_emy_data_section = .;
	}

	.my_function_section 0xA000:
	{
		/* */
		_my_function_section = .;
		*(.my_function_section )
		_emy_function_section= .;
	}
}