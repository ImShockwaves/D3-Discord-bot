using System;
using System.Drawing;
using d3bot.interfaces;
using System.Linq;

namespace d3bot.src.image_processing
{
	public class ProfileProc
	{

		public static void     profileProcessing(ProfileInt Profile, string account, bool playtime) {
			try {				
				Bitmap Template	= new Bitmap("data/img/profile_template.png");
				Graphics g = Graphics.FromImage(Template);
				string formattedAccount = account.Split('#')[0].ToUpper();
				drawAccountName(formattedAccount, g);
				statTemplating(g, Profile);
				heroTemplating(g, Profile);

				Template.Save("data/img/RenderedImage.png", System.Drawing.Imaging.ImageFormat.Png);
				g.Dispose();
				if (playtime) {
					displayPlaytime(Profile, formattedAccount);
				}
			}
			catch (OperationCanceledException e) {
				Console.WriteLine($"{nameof(OperationCanceledException)} thrown with message: {e.Message}");				
				throw;
			}
		}

		public static void		drawAccountName(string account, Graphics g) {
				
				SizeF size = g.MeasureString(account, new Font("exocet", 20, GraphicsUnit.Point));
				int startPosition = (252 - Convert.ToInt32(size.Width)) / 2;

				g.DrawString(account,
								new Font("exocet", 20), 
								new SolidBrush(Color.Red), 
								new PointF(278 + startPosition, 10));
		}

		public static void		displayPlaytime(ProfileInt Profile, string account) {
			
			float total = Profile.timePlayed.demon_hunter + Profile.timePlayed.barbarian + Profile.timePlayed.witch_doctor + 
							Profile.timePlayed.necromancer + Profile.timePlayed.wizard + Profile.timePlayed.monk
        					+ Profile.timePlayed.crusader;
			Bitmap Template	= new Bitmap("data/img/playtime_template.png");
			Bitmap Wiz_gauge = new Bitmap("data/img/wiz_gauge.png");
			Bitmap Dh_gauge = new Bitmap("data/img/dh_gauge.png");
			Bitmap Crus_gauge = new Bitmap("data/img/crus_gauge.png");
			Bitmap Wd_gauge = new Bitmap("data/img/wd_gauge.png");
			Bitmap Monk_gauge = new Bitmap("data/img/monk_gauge.png");
			Bitmap Nec_gauge = new Bitmap("data/img/nec_gauge.png");
			Bitmap Barb_gauge = new Bitmap("data/img/barb_gauge.png");
			Graphics g = Graphics.FromImage(Template);
			
			drawAccountName(account, g);

			int percentage = Convert.ToInt32((Profile.timePlayed.wizard / total) * 100);
			Rectangle GaugeCoord = new Rectangle(0, 0, (193 * percentage) / 100, 24);
			g.DrawImage(Wiz_gauge, 113, 457, GaugeCoord, GraphicsUnit.Pixel);
			g.DrawString("Wizard", 
							new Font("Palatino Linotype", 12, FontStyle.Bold, GraphicsUnit.Point), 
							new SolidBrush(Color.White), 132.91F, 435.8F);
			g.DrawString($"{percentage}%", 
							new Font("Palatino Linotype", 16, FontStyle.Bold, GraphicsUnit.Point), 
							new SolidBrush(Color.White), 315.86F, 462.0F);

			percentage = Convert.ToInt32((Profile.timePlayed.witch_doctor / total) * 100);
			GaugeCoord = new Rectangle(0, 0, (192 * percentage) / 100, 25);
			g.DrawImage(Wd_gauge, 517, 454, GaugeCoord, GraphicsUnit.Pixel);
			g.DrawString("Witch Doctor", 
							new Font("Palatino Linotype", 12, FontStyle.Bold, GraphicsUnit.Point), 
							new SolidBrush(Color.White), 532.98F, 435.8F);
			g.DrawString($"{percentage}%", 
							new Font("Palatino Linotype", 16, FontStyle.Bold, GraphicsUnit.Point), 
							new SolidBrush(Color.White), 718.54F,  460.0F);

			percentage = Convert.ToInt32((Profile.timePlayed.demon_hunter / total) * 100);
			GaugeCoord = new Rectangle(0, 0, (193 * percentage) / 100, 25);
			g.DrawImage(Dh_gauge, 108, 340, GaugeCoord, GraphicsUnit.Pixel);
			g.DrawString("Demon Hunter", 
							new Font("Palatino Linotype", 12, FontStyle.Bold, GraphicsUnit.Point), 
							new SolidBrush(Color.White), 129.32F, 319.6F);
			g.DrawString($"{percentage}%", 
							new Font("Palatino Linotype", 16, FontStyle.Bold, GraphicsUnit.Point), 
							new SolidBrush(Color.White), 314.75F, 345.24F);

			percentage = Convert.ToInt32((Profile.timePlayed.crusader / total) * 100);
			GaugeCoord = new Rectangle(0, 0, (194 * percentage) / 100, 24);
			g.DrawImage(Crus_gauge, 511, 238, GaugeCoord, GraphicsUnit.Pixel);
			g.DrawString("Crusader", 
							new Font("Palatino Linotype", 12, FontStyle.Bold, GraphicsUnit.Point), 
							new SolidBrush(Color.White), 530.72F, 215.08F);
			g.DrawString($"{percentage}%", 
							new Font("Palatino Linotype", 16, FontStyle.Bold, GraphicsUnit.Point), 
							new SolidBrush(Color.White), 718.54F, 241.96F);

			percentage = Convert.ToInt32((Profile.timePlayed.monk / total) * 100);
			GaugeCoord = new Rectangle(0, 0, (194 * percentage) / 100, 24);
			g.DrawImage(Monk_gauge, 511, 340, GaugeCoord, GraphicsUnit.Pixel);
			g.DrawString("Monk", 
							new Font("Palatino Linotype", 12, FontStyle.Bold, GraphicsUnit.Point), 
							new SolidBrush(Color.White), 529.41F, 318.05F);
			g.DrawString($"{percentage}%", 
							new Font("Palatino Linotype", 16, FontStyle.Bold, GraphicsUnit.Point), 
							new SolidBrush(Color.White), 718.54F, 345.24F);

			percentage = Convert.ToInt32((Profile.timePlayed.necromancer / total) * 100);
			GaugeCoord = new Rectangle(0, 0, (193 * percentage) / 100, 24);
			g.DrawImage(Nec_gauge, 318, 567, GaugeCoord, GraphicsUnit.Pixel);
			g.DrawString("Necromancer", 
							new Font("Palatino Linotype", 12, FontStyle.Bold, GraphicsUnit.Point), 
							new SolidBrush(Color.White), 338.5F, 545.41F);
			g.DrawString($"{percentage}%", 
							new Font("Palatino Linotype", 16, FontStyle.Bold, GraphicsUnit.Point), 
							new SolidBrush(Color.White), 521.14F, 571.92F);
			
			percentage = Convert.ToInt32((Profile.timePlayed.barbarian / total) * 100);
			GaugeCoord = new Rectangle(0, 0, (193 * percentage) / 100, 24);
			g.DrawImage(Barb_gauge, 108, 238, GaugeCoord, GraphicsUnit.Pixel);
			g.DrawString("Barbarian", 
							new Font("Palatino Linotype", 12, FontStyle.Bold, GraphicsUnit.Point), 
							new SolidBrush(Color.White), 127.47F, 215.7F);
			g.DrawString($"{percentage}%", 
							new Font("Palatino Linotype", 16, FontStyle.Bold, GraphicsUnit.Point), 
							new SolidBrush(Color.White), 310.28F, 241.77F);

			Template.Save("data/img/RenderedPlaytime.png", System.Drawing.Imaging.ImageFormat.Png);
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
