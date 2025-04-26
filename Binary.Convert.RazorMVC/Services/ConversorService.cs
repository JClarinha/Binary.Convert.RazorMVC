using System.Collections; // MVC Services - representa toda a lógica exixstente

public class ConversorService : IConversorService
{
    public string Converter(string tipoConversao, string input)
    {
        switch (tipoConversao)
        {
            case "DecimalParaBinario":
                return DecimalParaBinario(input);
            case "BinarioParaDecimal":
                return BinarioParaDecimal(input);
            case "DecimalparaHexadecimal":
                return DecimalParaHexadecimal(input);
            case "HexadecimalParaDecimal":
                return HexadecimalParaDecimal(input);
            default:
                return "Tipo de converção Inválido";
        }
    }

    private string DecimalParaBinario (string input)
    {
        if (!int.TryParse(input, out int x))
            return "Número inválido!"; // Verifica se o valor introduzido é válido

        List<int> b = new();
        while (x>0) // Executa enquanto o valor de x, inicialmente definido pelo utilizador, for maior que 0
        {
            b.Add(x % 2); // Adiciona na lista b o resto da divisão de x por 2 (0 ou 1)
            x/=2; // Atualiza x com o quociente da divisão por 2
        }
        
        if(b.Count == 0) b.Add(0); // No caso de o utilizador introduzir 0 o unico valor em lista é 0. 0 = 0 em binário.

        b.Reverse();
        return string.Join("",b); //Utilização de IEnumerable
        /*
            Equivalente mas com um foreach em vez de utilização de IEnumerable

                List<int> b = new List<int> { 1, 0, 1, 1 };
        string resultado = "";

        foreach (int bit in b)
        {
            resultado += bit.ToString(); // ou resultado += bit;
        }*/
            
        
    }

    private string BinarioParaDecimal (string input)
    {
        if(input.Any(c => c != '0' && c != '1')) //Verifica se o binario introduzido é apenas composto por 0 e 1
            return "Binário inválido!";

            input = new string (input.Reverse().ToArray()); //Neste caso o input é uma string e com o .Reverse estamos não só
            //a reverter a ordem dos caracteres como a passar a string para um IEnumerable<char> que em seguida passamos para Array de Chars.
            int total = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int bit = input[i] - '0'; // o valor de input[i] (char) aqui ou é 48 ou 49, correspondendo ao seu valor decimal na tabela de ASCII
                // Com isto conseguimos converter esse mesmo valor para o 0 ou 1 decimal.
                total += bit * (int)Math.Pow(2,i);
            }

            return total.ToString();
    }

    private string DecimalParaHexadecimal (string input)
    {
        if(!int.TryParse(input, out int x)) // Verifica se o que o utilizador introduz é um decimal válido
            return "Número inválido!";

        string hexChar = "0123456789ABCDEF"; // Cria uma string com todos os caracteres possiveis de um hexadecimal
        List<char> hex = new();

        while (x > 0) // Enquento o valor introduzido for maior que 0 continua o loop
        {
            hex.Add(hexChar[x % 16]); // Adiciona o resto da divisão de x por 16 à lista
            x /= 16; // igula ao quociente da divisão do mesmo por 16 de modo a diminuir de forma correto o valor de x
        }

        if (hex.Count() == 0) hex.Add('0'); // no caso do valor introduzido pelo utilizador ser 0 adiciona apenas esse ao array de modo a corresponder e não dar erro
        hex.Reverse();
        return string.Join("", hex); // Utilização do IEnumerable para conseguir retornar o array hex numa string completa

    }

    private string HexadecimalParaDecimal(string input)
    {
        string hexChar = "123456789ABCDEF"; //Cria uma string que contem todos os carateres possiveis num hexadecimal
        input = input.ToUpper(); // Altera todas as letras introduzidas pelo utilizador em maiusculas

        if(input.Any(c => !hexChar.Contains(c))) // Verifica se cada caracter que o utilizador introduziu existe na string de controlo
            return "Hexadecimal inválido!";

        int resultado = 0, exp = 0;

        for (int i = input.Length - 1; i>=0; i--)
        {
            char c = input[i]; // atribui o valor na posição da iteração do loop a um char
            int valor = char.IsDigit(c) ? c - '0' : c - 'A' + 10; // Converte o char num valor decimal utilizando os valores correspondentes na tabela de ASCII
            resultado += valor*(int)Math.Pow(16, exp++); // Faz o calculo para obtenção do hexadecimal em decimal
        }
        return resultado.ToString(); // Retona o valor decimal total numa string
    }

}