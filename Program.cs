Console.WriteLine("From Python ======");
Microsoft.Scripting.Hosting.ScriptEngine pythonEngine = IronPython.Hosting.Python.CreateEngine();
var scope = pythonEngine.CreateScope();

List<int> argv = new List<int>();  // Declare argv in C sharp.
argv.Add(500);
scope.SetVariable("argv", argv);   // Pass argv to python.

// Declare item01 in python.
// Print item01
// Print argv (from csharp)
string script =
@"item01 = 'Oh I am Gary.'
print('this is item01 from python:')
print(item01)
print('this is argv from csharp:')
print(argv[0])";
Microsoft.Scripting.Hosting.ScriptSource pythonScript = pythonEngine.CreateScriptSourceFromString(script);
pythonScript.Execute(scope);
var valueFromPython = scope.GetVariable<string>("item01");   // Pass item01 from python to csharp.

Console.WriteLine("End Python ======");
Console.WriteLine("");
Console.WriteLine("Back to C# ~~~~~~~");
Console.WriteLine($"The value of 'item01' is passed from python to csharp: {valueFromPython}");