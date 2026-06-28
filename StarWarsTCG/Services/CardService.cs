using Newtonsoft.Json;
using StarWarsTCG.Models;

namespace StarWarsTCG.Services
{
    public class CardService
    {
        private readonly HttpClient _httpClient = new();

        public async Task<List<Card>> GetCardsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://api.swu-db.com/cards/SOR");
                var content = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);

                if (apiResponse?.Data == null)
                    return new List<Card>();

                // Filtro porque la api trae algunas cartas duplicadas y dejo maxima 20 cartas porque eran demasiadas (900+)
                var uniqueCards = apiResponse.Data
                    .GroupBy(c => c.Name)
                    .Select(g => g.First())
                    .Take(20)
                    .Select(c => new Card
                    {
                        Name = c.Name,
                        Subtitle = c.Subtitle,
                        Rarity = c.Rarity,
                        FrontArt = c.FrontArt
                    })
                    .ToList();

                return uniqueCards;
            }
            catch
            {
                return new List<Card>();
            }
        }
    }
}