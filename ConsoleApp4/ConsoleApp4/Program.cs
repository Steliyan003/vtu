using System;

class Program
{
    static void Main(string[] args)
    {
        string dnaStrand = "GCTA";
        string rnaStrand = DnaToRna(dnaStrand);
        Console.WriteLine($"DNA: {dnaStrand} -> RNA: {rnaStrand}");
    }

    static string DnaToRna(string dna)
    {
        
        char[] rna = new char[dna.Length];

        // Преминаваме през всеки знак в ДНК веригата
        for (int i = 0; i < dna.Length; i++)
        {
            switch (dna[i])
            {
                case 'G':
                    rna[i] = 'C';
                    break;
                case 'C':
                    rna[i] = 'G';
                    break;
                case 'T':
                    rna[i] = 'A';
                    break;
                case 'A':
                    rna[i] = 'U';
                    break;
                default:
                    throw new ArgumentException($"Invalid nucleotide: {dna[i]}");
            }
        }

        return new string(rna);
    }
}



