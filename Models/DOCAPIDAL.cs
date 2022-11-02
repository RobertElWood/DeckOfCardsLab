using Microsoft.AspNetCore.DataProtection.KeyManagement;
using RestSharp;
using System.Runtime.CompilerServices;

namespace DeckofCardsAPILab.Models
{
    public class DOCAPIDAL
    {
        //Creates a brand new deck, can be used to start over.
        public NewDeck CreateDeck()
        {
            var client = new RestClient($"https://deckofcardsapi.com/api/deck/new/");
            var request = new RestRequest();
            var response = client.GetAsync<NewDeck>(request);
            NewDeck d = response.Result;
            return d;
        }

        //Shuffles deck at given ID of NewDeck object used as parameter.
        public ShuffledDeck ShuffleDeck(string deckId)
        {
            var client = new RestClient($"https://deckofcardsapi.com/api/deck/{deckId}/shuffle/");
            var request = new RestRequest();
            var response = client.GetAsync<ShuffledDeck>(request);
            ShuffledDeck e = response.Result;
            return e;
        }

        //Not sure if I'll need a call tos reshuffle, but included just in case
        public ShuffledDeck ReShuffleDeck(string deckId)
        {
            var client = new RestClient($"https://deckofcardsapi.com/api/deck/{deckId}/shuffle/?remaining=true");
            var request = new RestRequest();
            var response = client.GetAsync<ShuffledDeck>(request);
            ShuffledDeck r = response.Result;
            return r;
        }

        //Draws the number of cards specified from the shuffled deck.
        public DrawACard DrawCards(string deckId, int count)
        {
            var client = new RestClient($"https://deckofcardsapi.com/api/deck/{deckId}/draw/?count={count}");
            var request = new RestRequest();
            var response = client.GetAsync<DrawACard>(request);
            DrawACard d = response.Result;
            return d;
        }

        //Keeps cards from your hand, removing them from the shuffled deck.
        public AddToPiles KeepCards(string deckId, string cards)
        {
            var client = new RestClient($"https://deckofcardsapi.com/api/deck/{deckId}/pile/hand/add/?cards={cards}");
            var request = new RestRequest();
            var response = client.GetAsync<AddToPiles>(request);
            AddToPiles d = response.Result;
            return d;
        }
    }
}
