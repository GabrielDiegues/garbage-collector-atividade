using System.Text;

namespace GCLab;

// ===================================
// 5) Recurso externo sem Dispose
// ===================================
class Logger : IDisposable 
{
    private readonly StreamWriter _writer;
    public Logger(string path)
    {
        _writer = new StreamWriter(path, append: true, Encoding.UTF8);
    }

    public void WriteLines(int count)
    {
        for (int i = 0; i < count; i++)
            _writer.WriteLine($"linha {i}");
    }


    public void Dispose()
    {
        _writer.Flush();
        _writer.Dispose();
        GC.SuppressFinalize(this);
    }

    ~Logger()
    {
        Console.WriteLine("~Logger finalizer chamado (não dependa disso)");
        Dispose();
    }
}
