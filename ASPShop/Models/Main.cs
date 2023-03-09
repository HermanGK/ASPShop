using System.ComponentModel.DataAnnotations;

namespace ASPShop.Models;

public class Main
{
	[Key]
	public int Id { get; set; }
	public string? Name { get; set; }
	public int Price { get; set; }
	public string? Text { get; set; }

	public string? Img { get; set; }
	
	public string? Class { get; set;}

}
