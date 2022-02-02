namespace Bot;

public class FileTokenProvider : ITokenProvider
{

	public string ProvideToken()
	{
		return File.ReadAllText("D:\\token.cfg");
	}
}
