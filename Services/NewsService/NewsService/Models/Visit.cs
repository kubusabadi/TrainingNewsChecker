
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NewsService.Models;

public class Visit
{
    [Key]
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int ServerResponse { get; set; }
}
