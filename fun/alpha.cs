public class Alpha{
	public static string GetName(){
		return "Alphaman McAlphaface";
	}
	public static int GetAge(){
		return 19;
	}
	private static bool IsMale(){
		return false;
	}
	public static string GetHeShe(){
		if (IsMale()==true){
			return "he";
		} else {
			return "she";
		}
	}
}
