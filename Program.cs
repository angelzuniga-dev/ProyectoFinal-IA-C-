using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class Agente
{
    static readonly string API_KEY = Environment.GetEnvironmentVariable("GROQ_API_KEY") ?? "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";
    static readonly string URL     = "https://api.groq.com/openai/v1/chat/completions";
    static readonly string MODELO  = "llama-3.3-70b-versatile";

    static readonly string SYSTEM_PROMPT =
        "Tu nombre es Viernes. Eres un asistente experto en programación en C#. " +
        "Cuando te pregunten tu nombre, responde que te llamas Viernes. " +
        "Responde siempre en español, de forma clara y con ejemplos de código cuando sea necesario.";

    static async Task Main()
    {
        Console.WriteLine("Hola! Soy Viernes, tu asistente de programación.");
        Console.WriteLine("Escribe tu pregunta. Escribe 'salir' para terminar.\n");

        while (true)
        {
            Console.Write("Tú: ");
            string input = Console.ReadLine() ?? "";

            if (input.ToLower() == "salir") break;

            string respuesta = await PreguntarAsync(input);
            Console.WriteLine($"\nViernes: {respuesta}\n");
        }
    }

    static async Task<string> PreguntarAsync(string pregunta)
    {
        using var http = new HttpClient();
        http.DefaultRequestHeaders.Add("Authorization", $"Bearer {API_KEY}");

        var body = new
        {
            model    = MODELO,
            messages = new[]
            {
                new { role = "system", content = SYSTEM_PROMPT },
                new { role = "user",   content = pregunta }
            }
        };

        var respuesta = await http.PostAsync(URL,
            new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json"));

        string json = await respuesta.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        return doc.RootElement
                  .GetProperty("choices")[0]
                  .GetProperty("message")
                  .GetProperty("content")
                  .GetString() ?? "Sin respuesta";
    } 
}
