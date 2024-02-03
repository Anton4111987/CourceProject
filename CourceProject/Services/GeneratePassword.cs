using System.Text;

namespace CourceProject.Services
{
	public class GeneratePassword
	{
		int LengthPassword { get; set; }

		readonly char[] ArraySymbols = { 'A','B','C','D','I','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y',
				'Z','a','b','c','d','i','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','1','2','3','4','5',
			'6','7','8','9','0','~','!','@','#','$','%','^','&','*','(',')','_','+','-','=','{',':','}','.',',','№','?',',',']','[','}',';','/'};
		string Password { get; set; }


        public GeneratePassword(int LengthPassword)
		{
				this.LengthPassword = LengthPassword;
		}
		public GeneratePassword()
		{
			this.LengthPassword = 8;
		}
		public string Generate()
		{
			StringBuilder sb = new StringBuilder();

			Random random = new ();
			for (int j = 0; j < LengthPassword; j++)
			{
				int iter = random.Next(0, 87);
				sb.Append(ArraySymbols[iter]);

			}
			Password = sb.ToString();
			return Password;
		}

	}
}
