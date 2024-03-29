using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace react_demo_backend.Controllers
{
  public class FallbackController : Controller
  {
    public IActionResult Index()
    {
      return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(),
          "wwwroot", "index.html"), MediaTypeNames.Text.Html);
    }
  }
}
