using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mistox {
    class Unassembly {

        static string Cmd1(string CmdName, string V1, string Desc) {
            return CmdName + " " + V1 + " ; " + Desc;
        }
        static string Cmd2(string CmdName, string V1, string V2, string Desc) {
            return CmdName + " " + V1 + ", " + V2 + " ; " + Desc;
        }

        public static string Unassemble(string Command, string A, string B, string C) {

            // Rd = Register Number
            // Im = Immediate Number
            // Pc = Program Counter
            // Sc = Stack Conter
            // T = Status register for True / False
            // mmmm = source register
            // nnnn = destination register


            string nA = "0x" + Convert.ToString(Convert.ToInt32(A), 16);
            string nB = "0x" + Convert.ToString(Convert.ToInt32(B), 16);
            string nC = "0x" + Convert.ToString(Convert.ToInt32(C), 16);
            string nBC = "0x" + Convert.ToString(Convert.ToInt32(B + C), 16);

            //////////////////////////////////// Data Transfer Instructions ///////////////////////////////////////////////////////////

            if (Command == "1110") {
                return Cmd2("MOV", nBC, nA, "Data transfer, Immediate data transfer, Peripheral module data transfer, Structure data transfer, Reverse stack transfer");

            }

            //////////////////////////////////// Arithmatic Instructions ///////////////////////////////////////////////////////////

            else if (Command == "0011" && C == "1100") {
                return Cmd2("ADD", nB, nC, "Addition: ADD Rs, Rd | Rd + Rs => Rd");

            } else if (Command == "0111") {
                return Cmd2("ADD", nBC, nA, "Addition Immidiate: ADD imm, Rd | imm + Rd => Rd");

            } else if (Command == "0011" && C == "1110") {
                return Cmd2("ADDC", nB, nA, "ADD Carry: ADDC Rs, Rd | Rd + Rs + T => Rd, carry => T");

            } else if (Command == "0011" && C == "1111") {
                return Cmd2("ADDV", nB, nA, "ADD Overflow: ADDV Rs, Rd | Rd + Rs => Rd, overflow => T");

            } else if (Command == "1000" && A == "1000") {
                return Cmd2("CMP/EQ", nBC, "R0", "Is Equal: CMP/EQ Imm | if (Imm == Register0) => T");

            } else if (Command == "0011" && C == "0000") {
                return Cmd2("CMP/EQ", nB, nA, "Is Equal: CMP/EQ Rs, Rd | if (Rs == Rd) => T");

            } else if (Command == "0011" && C == "0010") {
                return Cmd2("CMP/HS", nB, nA, "Greater Then or Equal to(unsigned): CMP/HS Rs, Rd | if (Rs >= Rs) => T");

            } else if (Command == "0011" && C == "0011") {
                return Cmd2("CMP/GE", nB, nA, "Greater Than or Equal to(signed): CMP/GE Rs, Rd | if (Rs >= Rs) => T");

            } else if (Command == "0011" && C == "0110") {
                return Cmd2("CMP/HI", nB, nA, "Greater Then(unsigned): CMP/HI Rs, Rd | if (Rs > Rs) => T");

            } else if (Command == "0011" && C == "0111") {
                return Cmd2("CMP/GT", nB, nA, "Greater Then(signed): CMP/HI Rs, Rd | if (Rs > Rs) => T");

            } else if (Command == "0100" && B == "0001" && C == "0101") {
                return Cmd1("CMP/PL", nA, "Is positive > 0: CMP/PL Rd | if (Rd > 0) => T");

            } else if (Command == "0100" && B == "0001" && C == "0001") {
                return Cmd1("CMP/PZ", nA, "Is positive >= 0: CMP/PZ Rd | if (Rd >= 0) => T");

            } else if (Command == "0010" && C == "1100") {
                return Cmd2("CMP/STR", nB, nA, "Bytes Equal: CMP/STR Rs, Rd | if (Rs == Rs) => T");

            } else if (Command == "0100" && B == "1001" && C == "0001") {
                return Cmd1("CLIPS.B", nA, "");

            } else if (Command == "0100" && B == "1001" && C == "0101") {
                return Cmd1("CLIPS.W", nA, "");

            } else if (Command == "0100" && B == "1000" && C == "0001") {
                return Cmd1("CLIPU.B", nA, "");

            } else if (Command == "0100" && B == "1000" && C == "0101") {
                return Cmd1("CLIPU.W", nA, "");

            } else if (Command == "0011" && C == "0100") {
                return Cmd2("DIV1", nB, nA, "Division: DIV1 Rs, Rd | Rd / Rs = (?Rd)");

            } else if (Command == "0010" && C == "0111") {
                return Cmd2("DIV0S", nB, nA, "initilaization instruction for signed division.");

            }

            return "NOP";
        }

    }
}
