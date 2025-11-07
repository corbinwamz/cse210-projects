using System;

class Program
{
    static void Main(string[] args)
    {
        string activity = "Breathe";
        string activityDesc = "This activity will help you relax by walking you through breathing in and out slowly. Clearn your mind and focus on your breathing.";
        Activity breathActivity = new(activity, activityDesc);
        Breath breath = new(0, 0, activity, activityDesc);

        activity = "Reflection";
        activityDesc = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        Activity reflectionActivity = new(activity, activityDesc);
        List<string> reflectionPrompts = ["Think about a time when life felt rally heavy. What helped you keep going, even if it was just one tiny step?",
        "Remember a situation where you didn't get what you wanted? How did you adapt or make it through anyway?", "When did you handle something better than you would have a few years ago?"];
        Reflection reflection = new(reflectionPrompts, reflectionPrompts, activity, activityDesc);

        activity = "Listing";
        activityDesc = "This activity will help you relfect on the good things in your life by having you list as many things as you can in a certain area.";
        List<string> prompts = ["What challenge have I overcome recently that I’m proud of?", "How have I grown emotionally, intellectually, or spiritually in the past year?",
        "What’s a skill I’ve developed that my past self would be amazed by?"];
        List<string> promptReflections = ["How did you feel afterwards? ", "How did I rely on God? ", "How can I use what I learned to keep growing? "];
        Activity listingActivity = new(activity, activityDesc);
        Listing listing = new(prompts, activity, activityDesc);

        listingActivity.Menu(breathActivity, breath, reflectionActivity, reflection, listing);  
    }
}