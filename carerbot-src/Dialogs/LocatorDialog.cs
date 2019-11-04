using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

using System.Collections.Generic;
namespace Microsoft.Bot.Sample.QnABot
{
    [Serializable]
    public class LocatorDialog : IDialog<string>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await this.MessageReceivedAsync(context, null);
        }
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var message = context.MakeMessage();

            var actions = new List<CardAction>();

            actions.Add(new CardAction() { Title = "1.Alter", Value = "1", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "2.Bruges", Value = "2", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "3.Dlksmuide", Value = "3", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "4.East Flanders", Value = "4", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "5.Knokke-Heist", Value = "5", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "6.Kortrijk", Value = "6", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "7.Oostende", Value = "7", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "8.Roselare", Value = "8", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "9.Tielt", Value = "9", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "10.Torhout", Value = "10", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "11.Waregem", Value = "11", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "12.Ypres", Value = "12", Type = ActionTypes.ImBack });

            message.Attachments.Add(
                    new HeroCard
                    {
                        Title = "Please choose the municipality in which you are residing.",
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
                await context.PostAsync("Thuiszorg De Zon De Oost-Vlaamse afdeling van Familiezorg West-Vlaanderen vzw (Tel.09 371 92 27;Web. info@thuiszorgdezon.be;Add.Regiohuis Aalter Boomgaard 12 9880 Aalter)");
            }
            else if (selected == "2")
            {
                await context.PostAsync("1.Foton Expertisecentrum Dementie (Tel.050 44 67 93 E. foton@dementie.be; Add.Biskajersplein 2, 8000 Brugge)" + "2.Regiohuis Brugge (Tel.050 33 65 00;Web. brugge@familiezorg-wvl.be;Add.Regiohuis Brugge Sint-Jansplein 8000 Brugge)",
                "3.Training center Family care West Flanders vzw Brugge (Tel.050 33 02 70; E. education@familiezorg-wvl.be; Add.Family care West Flanders vzw Biskajersplein 3 8000 Brugge)" + 
                "4.Home nursing care 'the cradle' North West Flanders (Tel.050 33 38 53; E. dewieg@familiezorg-wvl.be; Add.Home nursing care 'the cradle' Ezelpoort 5 8000 Brugge)");
            }
            else if (selected == "3")
            {
                await context.PostAsync("Regiohuis Diksmuide (Tel.051 50 22 33; E. diksmuide@familiezorg-wvl.be; Add.Regiohuis Diksmuide De Breyne Peellaertstraat 52 8600 Diksmuide)");
            }
            else if (selected == "4")
            {
                await context.PostAsync("Thuiskraamzorg 'de wieg' Oost-Vlaanderen (Tel.0473 45 14 42; E. dewieg@familiezorg-wvl.be; Add.Thuiskraamzorg 'de wieg' Boomgaard 12 9880 Aalter)");
            } 
            else if (selected == "5")
            {
                await context.PostAsync("Regiohuis Ieper (Tel.057 20 12 14; E. ieper@familiezorg-wvl.be; Add.Regiohuis Ieper De Brouwerstraat 48900 Ieper)");
            }
            else if (selected == "6")
            {
                await context.PostAsync("1.Regiohuis Kortrijk (Tel.056 20 15 48; E. kortrijk@familiezorg-wvl.be; Add.Regiohuis Kortrijk Heilige Geeststraat 11 8500 Kortrijk)",
                "2.Opleidingscentrum Familiezorg West-Vlaanderen vzw Kortrijk (Tel.056 20 15 48; E. opleiding@familiezorg-wvl.be; Add.Familiezorg West-Vlaanderen vzw Heilige Geeststraat 11 8500 Kortrijk)");
            }
            else if (selected == "7")
            {
                await context.PostAsync("Regiohuis Oostende (Tel.059 70 69 53; E. oostende@familiezorg-wvl.be; Add.Regiohuis Oostende\nWellingtonstraat 70\n8400 Oostende)");
            }
            else if (selected == "8")
            {
                await context.PostAsync("1.Regiohuis Roeselare (Tel.051 22 08 01; E. roeselare@familiezorg-wvl.be; Add.Regiohuis Roeselare Leenstraat 31 8800 Roeselare)",
                "2.Expertisecentrum Kraamzorg 'de wieg' Zuid West-Vlaanderen (Tel.0479 95 17 90; E. info@dewieg.be; Add.Expertisecentrum Kraamzorg 'de wieg' Zuid Leenstraat 31 8800 Roeselare)");
            }
            else if (selected == "9")
            {
                await context.PostAsync("1.Regiohuis Tielt (Tel.051 40 04 43; E. tielt@familiezorg-wvl.be; Add.Regiohuis Tielt Krommewalstraat 1 8700 Tielt)", "2.Regionaal Dienstencentrum Zonnewende Kerkstraat(Tel. 051 40 44 85; E. ; Add.Regionaal Dienstencentrum Zonnewende Kerkstraat 15 8700 Tielt)");
            }
            else if (selected == "10")
            {
                await context.PostAsync("1.Regiohuis Torhout (Tel.050 21 41 82; E. torhout@familiezorg-wvl.be; Add.Regiohuis Torhout Sint-Rembertlaan 20 8820 Torhout)",
                "2.Expertisecentrum 'de wieg' Midden West-Vlaanderen (Tel.0473 45 14 38; E. info@dewieg.be; Add.Thuiskraamzorg 'de wieg' Sint-Rembertlaan 20 8820 Torhout)");
            }
            else if (selected == "11")
            {
                await context.PostAsync("1.Regiohuis Waregem (ook De Zon) (Tel.056 60 15 39; E. dewieg@familiezorg-wvl.be; Add.Regiohuis Waregem Guido Gezellestraat 10 8790 Waregem)",
                "2.Expertisecentrum Kraamzorg 'de wieg' Zuid West-Vlaanderen (Tel.0479 95 17 90; E. info@dewieg.be; Add.Regiohuis Waregem Guido Gezellestraat 10 8790 Waregem)");
            }
            else if (selected == "12")
            {
                await context.PostAsync("Regiohuis Ieper (Tel.057 20 12 14; Web. ieper@familiezorg-wvl.be; Add.Regiohuis Ieper De Brouwerstraat 4 8900 Ieper)");
            }

            else
            {
                await context.PostAsync("Please choose again.");
                context.Wait(SendWelcomeMessageAsync);
            }

        }
    }
}