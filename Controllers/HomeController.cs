using AutoMapper;
using CardGame.Models;
using CardGame.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CardGame.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICardDealerService _cardDealerService;
        private readonly IScoreService _scoreService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, ICardDealerService cardDealerService, IScoreService scoreService)
        {
            _logger = logger;
            _mapper = mapper;
            _cardDealerService = cardDealerService;
            _scoreService = scoreService;
        }

        public IActionResult Index()
        {
            var assignedPlayers = _cardDealerService.DealCardsToPlayers();

            foreach (var player in assignedPlayers)
            {
                player.Score = _scoreService.CalculateScore(player);
            }

            int winningPlayer = _scoreService.GetWinner(assignedPlayers);

            assignedPlayers.First(x => x.Id == winningPlayer).IsWinner = true;

            List<PlayerViewModel> players = assignedPlayers.Select(_mapper.Map<PlayerViewModel>).ToList();

            return View(players);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
