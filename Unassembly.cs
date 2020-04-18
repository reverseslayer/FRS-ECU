using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mistox {
    class Unassembly {

        static string Cmd2(string CmdName, string V1, string V2, string Desc) {
            return CmdName + " " + V1 + ", " + V2 + " ; " + Desc;
        }

        public static string Unassemble(string Command, string A, string B, string C) {

            // Rn = Register Number
            // Im = Immediate Number
            // Pc = Program Counter
            // Sc = Stack Conter
            // T = Status register for True / False


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
                return Cmd2("ADD", nB, nC, "Addition: ADD Rm, Rn | Rn + Rm => Rn");

            } else if (Command == "0111") {
                return Cmd2("ADD", nBC, nA, "Addition Immidiate: ADD imm, Rn | imm + Rn => Rn");

            } else if (Command == "0011" && C == "1110") {
                return Cmd2("ADDC", nB, nA, "ADD Carry: ADDC Rm, Rn | Rn + Rm + T => Rn, carry => T");

            } else if (Command == "0011" && C == "1111") {
                return Cmd2("ADDV", nB, nA, "ADD Overflow: ADDV Rm, Rn | Rn + Rm => Rn, overflow => T");

            } else if (Command == "1000" && A == "1000") {
                return Cmd2("CMP/EQ", nBC, "R0", "Is Equal: CMP/EQ Imm | if (Imm == Register0) => T");

            } else if (Command == "0011" && C == "0000") {
                return Cmd2("CMP/EQ", nB, nA, "Is Equal: CMP/EQ Rm, Rn | if (Rm == Rn) => T");

            } else if (Command == "0011" && C == "0010") {
                return Cmd2("CMP/HS", nB, nA, "Greater Than: CMP/HS Rm, Rn | if (Rm >= Rm) => T");
            
            }

            return "NOP";

        }

    }
}
