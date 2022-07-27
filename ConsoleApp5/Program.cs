using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace ConsoleApp5
{

    class Program
    {

        public static Program Instance { get; private set; }

        private readonly DiscordSocketClient _client;

        static void Main(string[] args)
            => new Program()
                .MainAsync()
                .GetAwaiter()
                .GetResult();

        public Program()
        {
            _client = new DiscordSocketClient();

            _client.Log += LogAsync;
            _client.Ready += ReadyAsync;
            _client.MessageReceived += MessageReceivedAsync;
            _client.InteractionCreated += InteractionCreatedAsync;
        }



        public async Task MainAsync()
        {
            Instance = this;





            await _client.LoginAsync(TokenType.Bot, "OTQ1MzI5MzMxNDY5Njg0ODI5.YhOkiw.1vM53H3GtviWpaTuXxLokUHEHSM");
            await _client.SetGameAsync("OwenHost.Com", "http://78.111.111.112/");

            await _client.StartAsync();

            await Task.Delay(Timeout.Infinite);

        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }



        private Task ReadyAsync()
        {
            Console.WriteLine($"{_client.CurrentUser} is connected!");

            return Task.CompletedTask;
        }




        private async Task MessageReceivedAsync(SocketMessage message)
        {
            SocketGuild guild = _client.GetGuild(953334465076273163);

            if (message.Author.Id == _client.CurrentUser.Id)
                return;

            switch (message.Content)
            {

                case "!destekaç":
                    var cb = new ComponentBuilder().WithButton("Destek Talebi Oluştur!", "DepartmanSeç", ButtonStyle.Success).Build();
                    var db = new EmbedBuilder().WithTitle("**Destek Talebi**").WithDescription("Sipariş ve destek için talep açabilirsiniz. Talep açmak için aşağıdaki butona tıklamanız yeterli.").WithImageUrl("https://owenhost.com/assets/img/logos/owenhost.png").Build();

                    await message.Channel.SendMessageAsync(" ", embed: db, components: cb);
                    break;




            }




        }


        private async Task InteractionCreatedAsync(SocketInteraction interaction)
        {
            Random rnd = new Random();

            if (interaction is SocketMessageComponent component)
            {

                SocketGuild guild = _client.GetGuild(954505745238458368);
                var user = _client.GetUser(component.User.Id);
                switch (component.Data.CustomId)
                {

                    case "DepartmanSeç":

                        int ids = rnd.Next(0000000, 9999999);
                        int idss = rnd.Next(0000000, 9999999);

                        var değer = $"{ids}{idss}";
                        var channel = guild.Channels.SingleOrDefault(x => x.Name == değer.ToString());

                        if (channel == null) // there is no channel with the name of 'log'
                        {
                            // create the channel
                            var newChannel = await guild.CreateTextChannelAsync(name: "Secim-" + değer, func: x => { x.CategoryId = 954514039478812772; });

                            await newChannel.ModifyAsync(c =>
                            {
                                c.PermissionOverwrites = new[]
                                {
                    new Overwrite(guild.EveryoneRole.Id, PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Deny)),
                    new Overwrite(user.Id, PermissionTarget.User, new OverwritePermissions(viewChannel: PermValue.Allow)),
                            };
                            });

                            var cb = new ComponentBuilder().WithButton("Satış Öncesi Destek", "satis", ButtonStyle.Success)
                                      .WithButton("Teknik Destek", "teknik", ButtonStyle.Success)
                                      .WithButton("Unturned Destek", "unturned", ButtonStyle.Danger)
                                      .WithButton("Fivem Destek", "fivem", ButtonStyle.Danger)
                                      .WithButton("Mta Destek", "mta", ButtonStyle.Primary)
                                      .WithButton("Minecraft Destek", "minecraft", ButtonStyle.Primary)
                                      .WithButton("Cs-Go Destek", "csgo", ButtonStyle.Secondary)
                                      .WithButton("Nested & Dedicated Destek", "nested", ButtonStyle.Secondary)
                                      .WithButton("Teamspeak Destek", "team", ButtonStyle.Danger)
                                      .WithButton("Kapat", "kapat", ButtonStyle.Danger).Build();
                            var db = new EmbedBuilder().WithTitle("**Departman Seçiniz!**").WithDescription("Departmanı Seçtikten Sonra Yetkili Ekibimiz Sizinle İletişime Geçecektir.").WithImageUrl("https://owenhost.com/assets/img/logos/owenhost.png").Build();

                            await newChannel.SendMessageAsync(" ", embed: db, components: cb);



                            var newChannelId = newChannel.Id;

                            
                        }
                        else
                        {
                            user.SendMessageAsync("Lütfen Tekrar Deneyiniz");
                        }

                        break;
                    case "satis":

                        var channelsx = guild.Channels.SingleOrDefault(x => x.Id == component.Channel.Id);
                        channelsx.DeleteAsync();


                        var channels = guild.Channels.SingleOrDefault(x => x.Name == "satis-" + user.Id);

                        if (channels == null) // there is no channel with the name of 'log'
                        {

                            // create the channel
                            var newChannels = await guild.CreateTextChannelAsync(name: "satis-" + user.Id, func: x => { x.CategoryId = 954505900050219049; });
                            await newChannels.ModifyAsync(c =>
                            {
                                c.PermissionOverwrites = new[]
                                {
                    new Overwrite(guild.EveryoneRole.Id, PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Deny)),
                    new Overwrite(user.Id, PermissionTarget.User, new OverwritePermissions(viewChannel: PermValue.Allow)),
                    new Overwrite(943196473942761522 , PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Allow)),
                    new Overwrite(943196467684859914  , PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Allow)),

                            };
                            });
                            var cb = new ComponentBuilder()

                                      .WithButton("Destek Talebini Kapat", "kapat", ButtonStyle.Danger)
                                      .WithButton("Departman Değiştir", "degistir", ButtonStyle.Success);

                            await newChannels.SendMessageAsync(" ", components: cb.Build());
                            var newChannelId = newChannels.Id;

                            try
                            {
                                var dc = new EmbedBuilder();
                                dc.WithTitle("OwenHost.Com | Destek Talebi");
                                dc.WithAuthor("OwenHost.Com", "https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                dc.WithDescription($"**Başarılı Bir Şekilde Destek Talebin Açıldı.** \n \n Destek Talebi: <#{newChannels.Id}>");
                                dc.WithThumbnailUrl("https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                dc.WithColor(Color.Purple);
                                dc.WithImageUrl("https://owenhost.com/assets/img/logos/owenhost.png");
                                dc.WithFooter("OwenHost | Destek Talebi", "https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                await user.SendMessageAsync(" ", false, dc.Build());
                            }
                            catch (Exception)
                            {


                            }
                        }


                        break;
                    case "teknik":

                        var channelssx = guild.Channels.SingleOrDefault(x => x.Id == component.Channel.Id);
                        channelssx.DeleteAsync();


                        var channelss = guild.Channels.SingleOrDefault(x => x.Name == "teknik-" + user.Id);

                        if (channelss == null) // there is no channel with the name of 'log'
                        {

                            // create the channel
                            var newChannels = await guild.CreateTextChannelAsync(name: "teknik-" + user.Id, func: x => { x.CategoryId = 954505900050219049; });
                            await newChannels.ModifyAsync(c =>
                            {
                                c.PermissionOverwrites = new[]
                                {
                    new Overwrite(guild.EveryoneRole.Id, PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Deny)),
                    new Overwrite(user.Id, PermissionTarget.User, new OverwritePermissions(viewChannel: PermValue.Allow)),
                    new Overwrite(943196473942761522 , PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Allow)),
                    new Overwrite(943196467684859914  , PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Allow)),

                            };
                            });
                            var cb = new ComponentBuilder()

                                      .WithButton("Destek Talebini Kapat", "kapat", ButtonStyle.Danger)
                                      .WithButton("Departman Değiştir", "degistir", ButtonStyle.Success);

                            await newChannels.SendMessageAsync(" ", components: cb.Build());
                            var newChannelId = newChannels.Id;
                            try
                            {
                                var dc = new EmbedBuilder();
                                dc.WithTitle("OwenHost.Com | Destek Talebi");
                                dc.WithAuthor("OwenHost.Com", "https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                dc.WithDescription($"**Başarılı Bir Şekilde Destek Talebin Açıldı.** \n \n Destek Talebi: <#{newChannels.Id}>");
                                dc.WithThumbnailUrl("https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                dc.WithColor(Color.Purple);
                                dc.WithImageUrl("https://owenhost.com/assets/img/logos/owenhost.png");
                                dc.WithFooter("OwenHost | Destek Talebi", "https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                await user.SendMessageAsync(" ", false, dc.Build());
                            }
                            catch (Exception)
                            {


                            }
                        }


                        break;
                    case "unturned":

                        var channelsssx = guild.Channels.SingleOrDefault(x => x.Id == component.Channel.Id);
                        channelsssx.DeleteAsync();


                        var channelsss = guild.Channels.SingleOrDefault(x => x.Name == "unturned-" + user.Id);

                        if (channelsss == null) // there is no channel with the name of 'log'
                        {

                            // create the channel
                            var newChannels = await guild.CreateTextChannelAsync(name: "unturned-" + user.Id, func: x => { x.CategoryId = 954505900050219049; });
                            await newChannels.ModifyAsync(c =>
                            {
                                c.PermissionOverwrites = new[]
                                {
                    new Overwrite(guild.EveryoneRole.Id, PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Deny)),
                    new Overwrite(user.Id, PermissionTarget.User, new OverwritePermissions(viewChannel: PermValue.Allow)),
                    new Overwrite(943196473942761522 , PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Allow)),
                    new Overwrite(943196467684859914  , PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Allow)),

                            };
                            });
                            var cb = new ComponentBuilder()

                                      .WithButton("Destek Talebini Kapat", "kapat", ButtonStyle.Danger)
                                      .WithButton("Departman Değiştir", "degistir", ButtonStyle.Success);

                            await newChannels.SendMessageAsync(" ", components: cb.Build());
                            var newChannelId = newChannels.Id;
                            try
                            {
                                var dc = new EmbedBuilder();
                                dc.WithTitle("OwenHost.Com | Destek Talebi");
                                dc.WithAuthor("OwenHost.Com", "https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                dc.WithDescription($"**Başarılı Bir Şekilde Destek Talebin Açıldı.** \n \n Destek Talebi: <#{newChannels.Id}>");
                                dc.WithThumbnailUrl("https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                dc.WithColor(Color.Purple);
                                dc.WithImageUrl("https://owenhost.com/assets/img/logos/owenhost.png");
                                dc.WithFooter("OwenHost | Destek Talebi", "https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                await user.SendMessageAsync(" ", false, dc.Build());
                            }
                            catch (Exception)
                            {


                            }
                        }


                        break;
                    case "fivem":

                        var channelssssx = guild.Channels.SingleOrDefault(x => x.Id == component.Channel.Id);
                        channelssssx.DeleteAsync();


                        var channelssss = guild.Channels.SingleOrDefault(x => x.Name == "fivem-" + user.Id);

                        if (channelssss == null) // there is no channel with the name of 'log'
                        {

                            // create the channel
                            var newChannels = await guild.CreateTextChannelAsync(name: "fivem-" + user.Id, func: x => { x.CategoryId = 954505900050219049; });
                            await newChannels.ModifyAsync(c =>
                            {
                                c.PermissionOverwrites = new[]
                                {
                    new Overwrite(guild.EveryoneRole.Id, PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Deny)),
                    new Overwrite(user.Id, PermissionTarget.User, new OverwritePermissions(viewChannel: PermValue.Allow)),
                    new Overwrite(943196473942761522 , PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Allow)),
                    new Overwrite(943196467684859914  , PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Allow)),

                            };
                            });
                            var cb = new ComponentBuilder()

                                      .WithButton("Destek Talebini Kapat", "kapat", ButtonStyle.Danger)
                                      .WithButton("Departman Değiştir", "degistir", ButtonStyle.Success);

                            await newChannels.SendMessageAsync(" ", components: cb.Build());
                            var newChannelId = newChannels.Id;
                            try
                            {
                                var dc = new EmbedBuilder();
                                dc.WithTitle("OwenHost.Com | Destek Talebi");
                                dc.WithAuthor("OwenHost.Com", "https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                dc.WithDescription($"**Başarılı Bir Şekilde Destek Talebin Açıldı.** \n \n Destek Talebi: <#{newChannels.Id}>");
                                dc.WithThumbnailUrl("https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                dc.WithColor(Color.Purple);
                                dc.WithImageUrl("https://owenhost.com/assets/img/logos/owenhost.png");
                                dc.WithFooter("OwenHost | Destek Talebi", "https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                await user.SendMessageAsync(" ", false, dc.Build());
                            }
                            catch (Exception)
                            {


                            }
                        }


                        break;
                    case "mta":

                        var channelsssssx = guild.Channels.SingleOrDefault(x => x.Id == component.Channel.Id);
                        channelsssssx.DeleteAsync();


                        var channelsssss = guild.Channels.SingleOrDefault(x => x.Name == "mta-" + user.Id);

                        if (channelsssss == null) // there is no channel with the name of 'log'
                        {

                            // create the channel
                            var newChannels = await guild.CreateTextChannelAsync(name: "mta-" + user.Id, func: x => { x.CategoryId = 954505900050219049; });
                            await newChannels.ModifyAsync(c =>
                            {
                                c.PermissionOverwrites = new[]
                                {
                    new Overwrite(guild.EveryoneRole.Id, PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Deny)),
                    new Overwrite(user.Id, PermissionTarget.User, new OverwritePermissions(viewChannel: PermValue.Allow)),
                    new Overwrite(943196473942761522 , PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Allow)),
                    new Overwrite(943196467684859914  , PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Allow)),

                            };
                            });
                            var cb = new ComponentBuilder()

                                      .WithButton("Destek Talebini Kapat", "kapat", ButtonStyle.Danger)
                                      .WithButton("Departman Değiştir", "degistir", ButtonStyle.Success);

                            await newChannels.SendMessageAsync(" ", components: cb.Build());
                            var newChannelId = newChannels.Id;
                            try
                            {
                                var dc = new EmbedBuilder();
                                dc.WithTitle("OwenHost.Com | Destek Talebi");
                                dc.WithAuthor("OwenHost.Com", "https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                dc.WithDescription($"**Başarılı Bir Şekilde Destek Talebin Açıldı.** \n \n Destek Talebi: <#{newChannels.Id}>");
                                dc.WithThumbnailUrl("https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                dc.WithColor(Color.Purple);
                                dc.WithImageUrl("https://owenhost.com/assets/img/logos/owenhost.png");
                                dc.WithFooter("OwenHost | Destek Talebi", "https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                await user.SendMessageAsync(" ", false, dc.Build());
                            }
                            catch (Exception)
                            {


                            }
                        }


                        break;
                    case "minecraft":

                        var channelssssssx = guild.Channels.SingleOrDefault(x => x.Id == component.Channel.Id);
                        channelssssssx.DeleteAsync();


                        var channelssssss = guild.Channels.SingleOrDefault(x => x.Name == "minecraft-" + user.Id);

                        if (channelssssss == null) // there is no channel with the name of 'log'
                        {

                            // create the channel
                            var newChannels = await guild.CreateTextChannelAsync(name: "minecraft-" + user.Id, func: x => { x.CategoryId = 954505900050219049; });
                            await newChannels.ModifyAsync(c =>
                            {
                                c.PermissionOverwrites = new[]
                                {
                    new Overwrite(guild.EveryoneRole.Id, PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Deny)),
                    new Overwrite(user.Id, PermissionTarget.User, new OverwritePermissions(viewChannel: PermValue.Allow)),
                    new Overwrite(943196473942761522 , PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Allow)),
                    new Overwrite(943196467684859914  , PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Allow)),

                            };
                            });
                            var cb = new ComponentBuilder()

                                      .WithButton("Destek Talebini Kapat", "kapat", ButtonStyle.Danger)
                                      .WithButton("Departman Değiştir", "degistir", ButtonStyle.Success);

                            await newChannels.SendMessageAsync(" ", components: cb.Build());
                            var newChannelId = newChannels.Id;
                            try
                            {
                                var dc = new EmbedBuilder();
                                dc.WithTitle("OwenHost.Com | Destek Talebi");
                                dc.WithAuthor("OwenHost.Com", "https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                dc.WithDescription($"**Başarılı Bir Şekilde Destek Talebin Açıldı.** \n \n Destek Talebi: <#{newChannels.Id}>");
                                dc.WithThumbnailUrl("https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                dc.WithColor(Color.Purple);
                                dc.WithImageUrl("https://owenhost.com/assets/img/logos/owenhost.png");
                                dc.WithFooter("OwenHost | Destek Talebi", "https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                await user.SendMessageAsync(" ", false, dc.Build());
                            }
                            catch (Exception)
                            {


                            }
                        }


                        break;
                    case "csgo":

                        var channelsssssssx = guild.Channels.SingleOrDefault(x => x.Id == component.Channel.Id);
                        channelsssssssx.DeleteAsync();


                        var channelsssssss = guild.Channels.SingleOrDefault(x => x.Name == "csgo-" + user.Id);

                        if (channelsssssss == null) // there is no channel with the name of 'log'
                        {

                            // create the channel
                            var newChannels = await guild.CreateTextChannelAsync(name: "csgo-" + user.Id, func: x => { x.CategoryId = 954505900050219049; });
                            await newChannels.ModifyAsync(c =>
                            {
                                c.PermissionOverwrites = new[]
                                {
                    new Overwrite(guild.EveryoneRole.Id, PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Deny)),
                    new Overwrite(user.Id, PermissionTarget.User, new OverwritePermissions(viewChannel: PermValue.Allow)),
                    new Overwrite(943196473942761522 , PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Allow)),
                    new Overwrite(943196467684859914  , PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Allow)),

                            };
                            });
                            var cb = new ComponentBuilder()

                                      .WithButton("Destek Talebini Kapat", "kapat", ButtonStyle.Danger)
                                      .WithButton("Departman Değiştir", "degistir", ButtonStyle.Success);

                            await newChannels.SendMessageAsync(" ", components: cb.Build());
                            var newChannelId = newChannels.Id;
                            try
                            {
                                var dc = new EmbedBuilder();
                                dc.WithTitle("OwenHost.Com | Destek Talebi");
                                dc.WithAuthor("OwenHost.Com", "https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                dc.WithDescription($"**Başarılı Bir Şekilde Destek Talebin Açıldı.** \n \n Destek Talebi: <#{newChannels.Id}>");
                                dc.WithThumbnailUrl("https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                dc.WithColor(Color.Purple);
                                dc.WithImageUrl("https://owenhost.com/assets/img/logos/owenhost.png");
                                dc.WithFooter("OwenHost | Destek Talebi", "https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                await user.SendMessageAsync(" ", false, dc.Build());
                            }
                            catch (Exception)
                            {


                            }
                        }


                        break;
                    case "nested":

                        var channelssssssssx = guild.Channels.SingleOrDefault(x => x.Id == component.Channel.Id);
                        channelssssssssx.DeleteAsync();


                        var channelssssssss = guild.Channels.SingleOrDefault(x => x.Name == "nested-" + user.Id);

                        if (channelssssssss == null) // there is no channel with the name of 'log'
                        {

                            // create the channel
                            var newChannels = await guild.CreateTextChannelAsync(name: "nested-" + user.Id, func: x => { x.CategoryId = 954505900050219049; });
                            await newChannels.ModifyAsync(c =>
                            {
                                c.PermissionOverwrites = new[]
                                {
                    new Overwrite(guild.EveryoneRole.Id, PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Deny)),
                    new Overwrite(user.Id, PermissionTarget.User, new OverwritePermissions(viewChannel: PermValue.Allow)),
                    new Overwrite(943196473942761522 , PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Allow)),
                    new Overwrite(943196467684859914  , PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Allow)),

                            };
                            });
                            var cb = new ComponentBuilder()

                                      .WithButton("Destek Talebini Kapat", "kapat", ButtonStyle.Danger)
                                      .WithButton("Departman Değiştir", "degistir", ButtonStyle.Success);

                            await newChannels.SendMessageAsync(" ", components: cb.Build());
                            var newChannelId = newChannels.Id;
                            try
                            {
                                var dc = new EmbedBuilder();
                                dc.WithTitle("OwenHost.Com | Destek Talebi");
                                dc.WithAuthor("OwenHost.Com", "https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                dc.WithDescription($"**Başarılı Bir Şekilde Destek Talebin Açıldı.** \n \n Destek Talebi: <#{newChannels.Id}>");
                                dc.WithThumbnailUrl("https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                dc.WithColor(Color.Purple);
                                dc.WithImageUrl("https://owenhost.com/assets/img/logos/owenhost.png");
                                dc.WithFooter("OwenHost | Destek Talebi", "https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                await user.SendMessageAsync(" ", false, dc.Build());
                            }
                            catch (Exception)
                            {


                            }
                        }


                        break;
                    case "team":

                        var channelsssssssssx = guild.Channels.SingleOrDefault(x => x.Id == component.Channel.Id);
                        channelsssssssssx.DeleteAsync();


                        var channelsssssssss = guild.Channels.SingleOrDefault(x => x.Name == "teamspeak-" + user.Id);

                        if (channelsssssssss == null) // there is no channel with the name of 'log'
                        {

                            // create the channel
                            var newChannels = await guild.CreateTextChannelAsync(name: "teamspeak-" + user.Id, func: x => { x.CategoryId = 954505900050219049; });
                            await newChannels.ModifyAsync(c =>
                            {
                                c.PermissionOverwrites = new[]
                                {
                    new Overwrite(guild.EveryoneRole.Id, PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Deny)),
                    new Overwrite(user.Id, PermissionTarget.User, new OverwritePermissions(viewChannel: PermValue.Allow)),
                    new Overwrite(943196473942761522 , PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Allow)),
                    new Overwrite(943196467684859914  , PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Allow)),

                            };
                            });
                            var cb = new ComponentBuilder()

                                      .WithButton("Destek Talebini Kapat", "kapat", ButtonStyle.Danger)
                                      .WithButton("Departman Değiştir", "degistir", ButtonStyle.Success);

                            await newChannels.SendMessageAsync(" ", components: cb.Build());
                            var newChannelId = newChannels.Id;
                            try
                            {
                                var dc = new EmbedBuilder();
                                dc.WithTitle("OwenHost.Com | Destek Talebi");
                                dc.WithAuthor("OwenHost.Com", "https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                dc.WithDescription($"**Başarılı Bir Şekilde Destek Talebin Açıldı.** \n \n Destek Talebi: <#{newChannels.Id}>");
                                dc.WithThumbnailUrl("https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                dc.WithColor(Color.Purple);
                                dc.WithImageUrl("https://owenhost.com/assets/img/logos/owenhost.png");
                                dc.WithFooter("OwenHost | Destek Talebi", "https://cdn.discordapp.com/attachments/954491524282994688/954506174869438485/oh1.png");
                                await user.SendMessageAsync(" ", false, dc.Build());
                            }
                            catch (Exception)
                            {


                            }
                        }


                        break;
                    case "degistir":

                        var channelsxxxdxx = guild.Channels.SingleOrDefault(x => x.Id == component.Channel.Id);
                        channelsxxxdxx.DeleteAsync();

                        var channeldd = guild.Channels.SingleOrDefault(x => x.Name == user.Username);

                        if (channeldd == null) // there is no channel with the name of 'log'
                        {
                            // create the channel
                            var newChannel = await guild.CreateTextChannelAsync(name: user.Username, func: x => { x.CategoryId = 954514039478812772; });


                            await newChannel.ModifyAsync(c =>
                            {
                                c.PermissionOverwrites = new[]
                                {
                    new Overwrite(guild.EveryoneRole.Id, PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Deny)),
                    new Overwrite(user.Id, PermissionTarget.User, new OverwritePermissions(viewChannel: PermValue.Allow)),
                            };
                            });
                            var cb = new ComponentBuilder().WithButton("Satış Öncesi Destek", "satis", ButtonStyle.Success)
                                           .WithButton("Teknik Destek", "teknik", ButtonStyle.Success)
                                           .WithButton("Unturned Destek", "unturned", ButtonStyle.Danger)
                                           .WithButton("Fivem Destek", "fivem", ButtonStyle.Danger)
                                           .WithButton("Mta Destek", "mta", ButtonStyle.Primary)
                                           .WithButton("Minecraft Destek", "minecraft", ButtonStyle.Primary)
                                           .WithButton("Cs-Go Destek", "csgo", ButtonStyle.Secondary)
                                           .WithButton("Nested & Dedicated Destek", "nested", ButtonStyle.Secondary)
                                           .WithButton("Teamspeak Destek", "team", ButtonStyle.Danger)
                                           .WithButton("Kapat", "kapat", ButtonStyle.Danger).Build();
                            var db = new EmbedBuilder().WithTitle("**Departman Seçiniz!**").WithDescription("Departmanı Seçtikten Sonra Yetkili Ekibimiz Sizinle İletişime Geçecektir.").WithImageUrl("https://owenhost.com/assets/img/logos/owenhost.png").Build();

                            await newChannel.SendMessageAsync(" ", embed: db, components: cb);


                            var newChannelId = newChannel.Id;

                        }
                        else
                        {
                            user.SendMessageAsync("En Fazla 1 Talep Açabilirsin");
                        }


                        break;
                    case "kapat":




                        var cbb = new ComponentBuilder().WithButton("Onayla!", "okapat", ButtonStyle.Success).WithButton("Vazgeç!", "ovazgeç", ButtonStyle.Danger).Build();

                        var ss = new EmbedBuilder().WithTitle($"{component.Channel.Name}").WithDescription("Adlı Destek Talebi Kapatılacaktır, Onaylıyormusunuz?").WithImageUrl("https://owenhost.com/assets/img/logos/owenhost.png").Build();

                        await component.Channel.SendMessageAsync(" ", embed: ss, components: cbb);




                        break;
                    case "ovazgeç":




                        var aass = new EmbedBuilder().WithTitle($"{component.Channel.Name}").WithDescription("Oda Kapama İşlemi İptal Edildi.").WithImageUrl("https://owenhost.com/assets/img/logos/owenhost.png").Build();

                        await component.Channel.SendMessageAsync(" ", embed: aass);




                        break;
                    case "okapat":

                        var cbbb = new ComponentBuilder().WithButton("1", "1", ButtonStyle.Success).WithButton("2", "2", ButtonStyle.Success).WithButton("3", "3", ButtonStyle.Success).WithButton("4", "4", ButtonStyle.Success).WithButton("5", "5", ButtonStyle.Success).Build();

                        var ass = new EmbedBuilder().WithTitle($"{component.Channel.Name}").WithDescription("Adlı Destek Talebi Kapatılacaktır, Bizi Puanlandırmaya Ne Dersiniz?").WithImageUrl("https://owenhost.com/assets/img/logos/owenhost.png").Build();

                        await component.Channel.SendMessageAsync(" ", embed: ass, components: cbbb);

                        break;
                    case "1":
                        var channelsxxxxdxx = guild.Channels.SingleOrDefault(x => x.Id == 954525978468696184);
                        var asss = new EmbedBuilder().WithTitle($"{component.Channel.Id}").WithDescription($"{component.Channel.Name} \n Puanlayan Kişi: {component.User.Username}-{component.User.Id} \n Puanı: 1").WithImageUrl("https://owenhost.com/assets/img/logos/owenhost.png").Build();
                        await _client.GetGuild(guild.Id).GetTextChannel(954525978468696184).SendMessageAsync(" ", embed: asss);
                        var channelsxxxxxdxx = guild.Channels.SingleOrDefault(x => x.Id == component.Channel.Id);
                        channelsxxxxxdxx.DeleteAsync();
                        break;
                    case "2":
                        var channelsxxxxxxdxx = guild.Channels.SingleOrDefault(x => x.Id == 954525978468696184);
                        var asssss = new EmbedBuilder().WithTitle($"{component.Channel.Id}").WithDescription($"{component.Channel.Name} \n Puanlayan Kişi: {component.User.Username}-{component.User.Id} \n Puanı: 2").WithImageUrl("https://owenhost.com/assets/img/logos/owenhost.png").Build();
                        await _client.GetGuild(guild.Id).GetTextChannel(954525978468696184).SendMessageAsync(" ", embed: asssss);
                        var channelsxxxxxxxdxx = guild.Channels.SingleOrDefault(x => x.Id == component.Channel.Id);
                        channelsxxxxxxxdxx.DeleteAsync();
                        break;
                    case "3":
                        var channelsxxxxxxxxdxx = guild.Channels.SingleOrDefault(x => x.Id == 954525978468696184);
                        var asssssss = new EmbedBuilder().WithTitle($"{component.Channel.Id}").WithDescription($"{component.Channel.Name} \n Puanlayan Kişi: {component.User.Username}-{component.User.Id} \n Puanı: 3").WithImageUrl("https://owenhost.com/assets/img/logos/owenhost.png").Build();
                        await _client.GetGuild(guild.Id).GetTextChannel(954525978468696184).SendMessageAsync(" ", embed: asssssss);
                        var channelsxxxxxxxxxdxx = guild.Channels.SingleOrDefault(x => x.Id == component.Channel.Id);
                        channelsxxxxxxxxxdxx.DeleteAsync();
                        break;
                    case "4":
                        var channelsxxxxxxxxxxdxx = guild.Channels.SingleOrDefault(x => x.Id == 954525978468696184);
                        var asssssssss = new EmbedBuilder().WithTitle($"{component.Channel.Id}").WithDescription($"{component.Channel.Name} \n Puanlayan Kişi: {component.User.Username}-{component.User.Id} \n Puanı: 4").WithImageUrl("https://owenhost.com/assets/img/logos/owenhost.png").Build();
                        await _client.GetGuild(guild.Id).GetTextChannel(954525978468696184).SendMessageAsync(" ", embed: asssssssss);
                        var channelsxxxxxxxxxxxdxx = guild.Channels.SingleOrDefault(x => x.Id == component.Channel.Id);
                        channelsxxxxxxxxxxxdxx.DeleteAsync();
                        break;
                    case "5":
                        var channelsxxxxxxxxxxxxdxx = guild.Channels.SingleOrDefault(x => x.Id == 954525978468696184);
                        var asssssssssss = new EmbedBuilder().WithTitle($"{component.Channel.Id}").WithDescription($"{component.Channel.Name} \n Puanlayan Kişi: {component.User.Username}-{component.User.Id} \n Puanı: 5").WithImageUrl("https://owenhost.com/assets/img/logos/owenhost.png").Build();
                        await _client.GetGuild(guild.Id).GetTextChannel(954525978468696184).SendMessageAsync(" ", embed: asssssssssss);
                        var channelsxxxxxxxxxxxxxdxx = guild.Channels.SingleOrDefault(x => x.Id == component.Channel.Id);
                        channelsxxxxxxxxxxxxxdxx.DeleteAsync();
                        break;
                }

            }
        }
    }
}