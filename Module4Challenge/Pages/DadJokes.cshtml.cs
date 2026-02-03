using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Module4Challenge.Pages
{
    public class DadJokesModel : PageModel
    {
        // 1. Declare an array holding 12 Dad Jokes
        // 'private readonly' because the list shouldn't change
        private readonly string[] _allJokes = new string[]
        {
            "I'm afraid for the calendar. Its days are numbered.",
            "My wife said I should do lunges to stay in shape. That would be a big step forward.",
            "Why do fathers take an extra pair of socks when they go golfing? In case they get a hole in one!",
            "Singing in the shower is fun until you get soap in your mouth. Then it's a soap opera.",
            "What do a tick and the Eiffel Tower have in common? They're both Paris sites.",
            "What do you call a fish wearing a bowtie? Sofishticated.",
            "What does a baby computer call his father? Data.",
            "If April showers bring May flowers, what do May flowers bring? Pilgrims.",
            "I thought the dryer was shrinking my clothes. Turns out it was the refrigerator all along.",
            "How does dry skin affect you at work? You don’t have any elbow grease to put into it.",
            "What do you call a factory that makes okay products? A satisfactory.",
            "Dear Math, grow up and solve your own problems."
        };

        // 2. Properties to store current jokes and count
        // using a list so we can easily add items dynamically
        public List<string> CurrentJokes { get; set; } = new List<string>();

        // How many jokes to show at once (Defaulting to 3)
        public int JokesToShow { get; set; } = 3;

        // 3. OnGet Method runs automatically when the page first loads
        public void OnGet()
        { //Select the initial jokes
            PickRandomJokes();
        }

        // 4. OnPost Method (Handles the button click) - Runs when the user submits the form
        public void OnPost()
        {
            // Pick new jokes when the button is clicked
            PickRandomJokes();
        }

        // Helper method handles the logic to populate CurrentJokes
        private void PickRandomJokes()
        { //Reset the list so we don't add the the old ones
            CurrentJokes.Clear();
            System.Random random = new System.Random();

            // 5. Logic to avoid showing the same joke twice in the current list
            while (CurrentJokes.Count < JokesToShow)
            {
                // Pick a random index on the array length
                int index = random.Next(_allJokes.Length);
                string selectedJoke = _allJokes[index];

                // Check if we already added this joke to the current list
                if (!CurrentJokes.Contains(selectedJoke))
                {
                    CurrentJokes.Add(selectedJoke);
                }
                // If the joke IS in the list, the loop runs again to find a new one
            }
        }
    }
}