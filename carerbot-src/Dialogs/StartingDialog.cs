using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

using System.Collections.Generic;
namespace Microsoft.Bot.Sample.QnABot
{
    [Serializable]
    public class StartingDialog : IDialog<object>
    {
        private string WelcomeMessage = "Hello. My name is Carerbot. I am here to assist you with your caregiving.";

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync(WelcomeMessage);

            var message = context.MakeMessage();

            var actions = new List<CardAction>();

            actions.Add(new CardAction() { Title = "1.Carer Support Center Locator", Value = "1", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "2.Questions about Caregiving", Value = "2", Type = ActionTypes.ImBack });

            message.Attachments.Add(
                    new HeroCard
                    {
                        Title = "Please choose the option on which you would like to get assisted.",
                        Buttons = actions
                    }.ToAttachment()
                );

            await context.PostAsync(message);

            context.Wait(SendWelcomeMessageAsync);
        }

        private async Task SendWelcomeMessageAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            string selected = activity.Text.Trim();

            if (selected == "1")
            {
                await context.PostAsync("This is carer support center locator. Please type in the province that you are currently residing in.");
                context.Call(new LocatorDialog(), DialogResumeAfter);
            }
            else if (selected == "2")
            {
                await context.PostAsync("Please type in the question that you have about caregiving. I can answer inquiries about (1) dementia, (2) caregiving to dementia care recipients, and (3) caring for caregivers");
            }
            else
            {
                await context.PostAsync("Please choose again.");
                context.Wait(SendWelcomeMessageAsync);
            }
        }
        private async Task DialogResumeAfter(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                string message = await result;

                //await context.PostAsync(WelcomeMessage); ;
                await this.MessageReceivedAsync(context, result);
            }
            catch (TooManyAttemptsException)
            {
                await context.PostAsync("Sorry. There was an error. Please try again.");
            }
        }
    }
}