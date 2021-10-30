using System;
using System.ComponentModel.DataAnnotations;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;
using System.Globalization;


namespace Template.Models
{
  public class Placeholder
  {
    public int PlaceholderId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Type { get; set; }
    [Range(0, 1, ErrorMessage = "Please enter a decimal between 0 and 1")]
    public double Score { get; set; }
  }

  public sealed class PlaceholderMap : ClassMap<Placeholder>
  {
    public PlaceholderMap()
    {
        AutoMap(CultureInfo.InvariantCulture);
        Map(m => m.PlaceholderId).Ignore();
    }
  }
}
