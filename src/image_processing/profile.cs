using System;
using System.Drawing;
using d3bot.interfaces;
using System.Linq;

namespace d3bot.src.image_processing
{
	public class ProfileProc
	{
		public static void     profileProcessing(ProfileInt Profile, string account) {
			Bitmap Template	= new Bitmap("data/img/profile_template.png");
			Graphics g = Graphics.FromImage(Template);
			string formattedAccount = account.Split('#')[0].ToUpper();
			SizeF size = g.MeasureString(formattedAccount, new Font("exocet", 20, GraphicsUnit.Point));
			int startPosition = (252 - Convert.ToInt32(size.Width)) / 2;

			g.DrawString(formattedAccount,
							new Font("exocet", 20), 
							new SolidBrush(Color.Red), 
							new PointF(278 + startPosition, 10));

			statTemplating(g, Profile);
			heroTemplating(g, Profile);

			Template.Save("data/img/RenderedImage.png", System.Drawing.Imaging.ImageFormat.Png);
		}

		public static void		statTemplating(Graphics g, ProfileInt Profile) {
			g.DrawString($"({Profile.paragonLevel})", 
							new Font("Palatino Linotype", 20), 
							new SolidBrush(ProfileDraw.ParColor), 
							new PointF(685, 221));
			g.DrawString($"({Profile.paragonLevelHardcore})", 
							new Font("Palatino Linotype", 20), 
							new SolidBrush(ProfileDraw.ParColor), 
							new PointF(685, 279));
			g.DrawString($"({Profile.paragonLevelSeason})", 
							new Font("Palatino Linotype", 20), 
							new SolidBrush(ProfileDraw.ParColor), 
							new PointF(685, 337));
			g.DrawString($"({Profile.paragonLevelSeasonHardcore})", 
							new Font("Palatino Linotype", 20), 
							new SolidBrush(ProfileDraw.ParColor), 
							new PointF(685, 395));

			g.DrawString(Profile.kills.monsters.ToString("#,##0"), 
							new Font("Palatino Linotype", 18), 
							new SolidBrush(Color.White), 
							new PointF(581, 495));
			g.DrawString(Profile.kills.elites.ToString("#,##0"), 
							new Font("Palatino Linotype", 18), 
							new SolidBrush(Color.White),
							new PointF(541, 551));
			g.DrawString(Profile.kills.hardcoreMonsters.ToString("#,##0"), 
							new Font("Palatino Linotype", 18), 
							new SolidBrush(Color.White), 
							new PointF(655, 612));
		}

		public static void		heroTemplating(Graphics g, ProfileInt Profile) {
			int maxValue = Profile.heroes.Max(hero => hero.kills.elites);
			int index = Array.FindIndex(Profile.heroes, hero => hero.kills.elites == maxValue);
			Heroes MostPlayed = Profile.heroes[index];
			Bitmap HeroTemplate	= new Bitmap($"data/img/{MostPlayed.classSlug}_{(MostPlayed.gender == 1 ? "female" : "male")}_portrait.png");
			SizeF size = g.MeasureString(MostPlayed.name, new Font("Palatino Linotype", 20, GraphicsUnit.Point));
			int startPosition = (236 - Convert.ToInt32(size.Width)) / 2;

			g.DrawImage(HeroTemplate, 33, 218, 292, 316);
			g.DrawString($"{MostPlayed.level}", 
							new Font(new FontFamily("Arial Black"), 18, GraphicsUnit.Point), 
							new SolidBrush(ProfileDraw.BasicColor), 
							new PointF(276, 483));
			g.DrawString(MostPlayed.name, 
							new Font("Palatino Linotype", 20), 
							new SolidBrush(ProfileDraw.BasicColor), 
							new PointF(61 + startPosition, 446));

			string clas;
			Color ClassColor;
			switch (MostPlayed.classSlug)
			{
				case "wizard":
					clas = "Wizard";
					ClassColor = ProfileDraw.wiz;
					break;
				case "demon-hunter":
					clas = "Demon-h.  ";
					ClassColor = ProfileDraw.dh;
					break;
				case "witch-doctor":
					clas = "Witch-d.  ";
					ClassColor = ProfileDraw.wd;
					break;
				case "crusader":
					clas = "Crusader  ";
					ClassColor = ProfileDraw.crus;
					break;
				case "necromancer":
					clas = "Necro.  ";
					ClassColor = ProfileDraw.nec;
					break;
				case "barbarian":
					clas = "Barb.  ";
					ClassColor = ProfileDraw.barb;
					break;
				default:
					clas = "Monk  ";
					ClassColor = ProfileDraw.monk;
					break;
			}
			string gender = MostPlayed.gender == 1 ? "Female" : "Male";
			SizeF genderSize = g.MeasureString($"{gender}i", new Font("Palatino Linotype", 15, GraphicsUnit.Point));
			SizeF classSize = g.MeasureString($"{clas}i", new Font("Palatino Linotype", 15, GraphicsUnit.Point));
			SizeF parSize = g.MeasureString($"({MostPlayed.paragonLevel})", new Font("Palatino Linotype", 15, GraphicsUnit.Point));
			int fullSize = Convert.ToInt32(genderSize.Width + classSize.Width + parSize.Width);
			Console.WriteLine(fullSize);
			startPosition = (226 - fullSize) / 2;
			

			int start = 50 + startPosition;
			g.DrawString(gender, 
							new Font("Palatino Linotype", 15, GraphicsUnit.Point), 
							new SolidBrush(ProfileDraw.BasicColor), 
							new PointF(start, 493));
			g.DrawString(clas, 
							new Font("Palatino Linotype", 15, GraphicsUnit.Point), 
							new SolidBrush(ClassColor), 
							new PointF(start + Convert.ToInt32(genderSize.Width), 493));
			g.DrawString($"({MostPlayed.paragonLevel})", 
							new Font("Palatino Linotype", 15, GraphicsUnit.Point), 
							new SolidBrush(ProfileDraw.ParColor), 
							new PointF(start + Convert.ToInt32(genderSize.Width) + Convert.ToInt32(classSize.Width), 493));
			
			size = g.MeasureString(Profile.guildName.ToUpper(), new Font("exocet", 18, GraphicsUnit.Point));
			startPosition = (292 - Convert.ToInt32(size.Width)) / 2;
			g.DrawString(Profile.guildName.ToUpper(), 
							new Font("exocet", 18, GraphicsUnit.Point), 
							new SolidBrush(ProfileDraw.GuildColor), 
							new PointF(33 + startPosition, 600));

		}
	}
}
