namespace ImageHash.Tests;

public abstract class Conftest : IDisposable
/*
* Test Setup class
* Func:: Dispose: Test clean up function.
* Func:: Restore input functionality
* Func:: Restore output functionality
 */
{
    // DI Injection
    private readonly TextReader _originalInput;
    private readonly TextWriter _originalOutput;
    private TextReader _input;
    private TextWriter _output;

    protected Conftest()
    /*
     * Func:: Dispose: Test clean up function.
     * Func:: Restore input functionality
     * Func:: Restore output functionality
     */
    {
        // Store original console I/O
        _originalInput = Console.In;
        _originalOutput = Console.Out;
        
        // Initialization with the current console I/O ops
        _input = Console.In;
        _output = Console.Out;
    }

    public void Dispose()
    /*
     * Dispose: Restores Console I/O operations to original state.
     */
    {
        Console.SetIn(_originalInput);
        Console.SetOut(_originalOutput);
        
        //Close all test console I/O 
        _input.Dispose();
        _output.Dispose();
    }

    protected void SetInput(TextReader reader)
    /*
     * SetInput: Test Console Input setup
     * @reader: of Type TextReader, can read a sequential series of characters to a stream
     */
    {
        Console.SetIn(reader);
        _input = reader;
    }

    protected void SetOutput(TextWriter writer)
    /*
     * SetOutput: Test Console Output setup
     * @writer: of Type TextReader, can write a characters to a stream
     */
    {
        Console.SetOut(writer);
        _output = writer;
    }
}

public class InputProviderWrapper
{
    public virtual string GetInput()
    {
        return Console.ReadLine() ?? string.Empty;
    }
}