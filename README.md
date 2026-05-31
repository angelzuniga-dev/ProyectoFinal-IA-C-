# ProyectoFinal-IA-C-

Aquí tienes una descripción formal, atractiva y bien estructurada para tu proyecto. Puedes utilizarla para el archivo README.md de tu repositorio de GitHub, para la documentación del código o para presentarla ante tus compañeros o clientes.

Agente Viernes: Asistente de Programación en C# con Groq API
Este proyecto es una aplicación de consola desarrollada en C# (.NET) que implementa un agente de Inteligencia Artificial conversacional llamado Viernes. El agente utiliza la infraestructura de Groq y el modelo de lenguaje de última generación Llama 3.3 (70B) para ofrecer respuestas rápidas, precisas y especializadas en desarrollo de software, actuando como un copiloto de programación interactivo directamente en la terminal.

Características Principales
Integración con Groq API: Consumo eficiente de LLMs utilizando las capacidades de baja latencia de Groq.

Modelo de Alta Capacidad: Implementación de llama-3.3-70b-versatile, ideal para tareas complejas de razonamiento y generación de código.

Personalización de Rol (System Prompt): Configurado específicamente para comportarse como un experto en desarrollo C#, respondiendo siempre en español y proporcionando ejemplos prácticos de código.

Asincronía Nativa (async/await): El procesamiento de peticiones HTTP se maneja de forma no bloqueante para garantizar la fluidez de la aplicación.

Seguridad: Soporte para la gestión de credenciales mediante variables de entorno (GROQ_API_KEY).

Tecnologías Utilizadas
Lenguaje: C#

Plataforma: .NET Core / .NET modern

Bibliotecas Nativas:

System.Net.Http para la comunicación con la API REST.

System.Text.Json para la serialización y deserialización eficiente de las peticiones y respuestas JSON.

Cómo Funciona El Código
El núcleo de la aplicación sigue un flujo sencillo pero robusto:

Inicialización: El programa lee la clave de la API (priorizando variables de entorno) y define las directrices del sistema.

Bucle de Conversación (while): Captura de manera continua la entrada del usuario en la consola hasta que se escribe la palabra clave salir.

Construcción de la Petición: Se empaqueta un objeto anónimo con la estructura requerida por la arquitectura tipo OpenAI (System Prompt + User Prompt).

Consumo de la API: Se envía una petición POST asíncrona hacia los endpoints de Groq.

Extracción de la Respuesta: Mediante un análisis dinámico del JSON (JsonDocument), se extrae limpiamente el texto de la respuesta generado por la IA y se muestra en pantalla.
