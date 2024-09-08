using NewsService.Interfaces;

namespace NewsService.Services
{
    public class TempService : ITempService
    {
        public string CreateTempContent()
        {
            return "Temp Content";
        }
    }
}
