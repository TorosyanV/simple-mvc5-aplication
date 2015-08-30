namespace UserStories.DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UserStories.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
            
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Groups.Count() == 0)
            {

                Group group1 = new Group();
                group1.Name = "Space";
                group1.Stories.Add(new Story()
                {
                    Title = "Moon",
                    Description = "This article is about Earth's natural satellite. For moons in general, see Natural satellite. For other uses, see Moon (disambiguation).",
                    Content = "The Moon (Latin: Luna) is Earth's only natural satellite.[e][9] It is one of the largest natural satellites in the Solar System, and, among planetary satellites, the largest relative to the size of the planet it orbits (its primary).[f][g] It is the second-densest satellite among those whose densities are known (after Jupiter's satellite Io).The Moon is thought to have formed approximately 4.5 billion years ago, not long after Earth. There are several hypotheses for its origin; the most widely accepted explanation is that the Moon formed from the debris left over after a giant impact between Earth and a Mars-sized body called Theia.The Moon is in synchronous rotation with Earth, always showing the same face with its near side marked by dark volcanic maria that fill between the bright ancient crustal highlands and the prominent impact craters. It is the second-brightest regularly visible celestial object in Earth's sky (after the Sun), as measured by illuminance on Earth's surface. Although it can appear a very bright white, its surface is actually dark, with a reflectance just slightly higher than that of worn asphalt. Its prominence in the sky and its regular cycle of phases have, since ancient times, made the Moon an important cultural influence on language, calendars, art, and mythology.The Moon's gravitational influence produces the ocean tides, body tides, and the slight lengthening of the day. The Moon's current orbital distance is about thirty times the diameter of Earth, causing it to have an apparent size in the sky almost the same as that of the Sun. This allows the Moon to cover the Sun nearly precisely in total solar eclipse. This matching of apparent visual size is a coincidence. The Moon's linear distance from Earth is currently increasing at a rate of 3.82 ± 0.07 centimetres (1.504 ± 0.028 in) per year, but this rate is not constant.",
                    PostedOn = DateTime.Now,
                });
                group1.Stories.Add(new Story()
                {
                    Title = "Mars",
                    Description = "This article is about the planet. For other uses, see Mars (disambiguation).",
                    Content = "Mars is the fourth planet from the Sun and the second smallest planet in the Solar System, after Mercury. Named after the Roman god of war, it is often referred to as the 'Red Planet' because the iron oxide prevalent on its surface gives it a reddish appearance.[15] Mars is a terrestrial planet with a thin atmosphere, having surface features reminiscent both of the impact craters of the Moon and the volcanoes, valleys, deserts, and polar ice caps of Earth. The rotational period and seasonal cycles of Mars are likewise similar to those of Earth, as is the tilt that produces the seasons. Mars is the site of Olympus Mons, the largest volcano and second-highest known mountain in the Solar System, and of Valles Marineris, one of the largest canyons in the Solar System. The smooth Borealis basin in the northern hemisphere covers 40% of the planet and may be a giant impact feature.[16][17] Mars has two moons, Phobos and Deimos, which are small and irregularly shaped. These may be captured asteroids,[18][19] similar to 5261 Eureka, a Mars trojan.Until the first successful Mars flyby in 1965 by Mariner 4, many speculated about the presence of liquid water on the planet's surface. This was based on observed periodic variations in light and dark patches, particularly in the polar latitudes, which appeared to be seas and continents; long, dark striations were interpreted by some as irrigation channels for liquid water. These straight line features were later explained as optical illusions, though geological evidence gathered by unmanned missions suggests that Mars once had large-scale water coverage on its surface at some earlier stage of its life.[20] In 2005, radar data revealed the presence of large quantities of water ice at the poles[21] and at mid-latitudes.[22][23] The Mars rover Spirit sampled chemical compounds containing water molecules in March 2007. The Phoenix lander directly sampled water ice in shallow Martian soil on July 31, 2008.[24]",
                    PostedOn = DateTime.Now,
                });
                group1.Stories.Add(new Story()
                {
                    Title = "Earth",
                    Description = "From Wikipedia, the free encyclopedia",
                    Content = "The Earth is the third planet from the Sun and it is the only planet known to have life on it. The Earth formed around 4.5 billion years ago.[5] It is one of four rocky planets on the inside of the Solar System. The other three are Mercury, Venus, and Mars.The large mass of the Sun makes the Earth move around it, just as the mass of the Earth makes the Moon move around it. The Earth also turns round in space, so different parts face the Sun at different times. The Earth goes around the Sun once (one'year') for every 365¼ times it turns all the way around (one 'day).The Moon goes around the Earth about every 27⅓ days, and reflects light from the Sun. As the Earth goes round the Sun at the same time, the changing light of the Moon takes about 29½ days to go from dark to bright to dark again. That is where the idea of 'month' came from. However, now most months have 30 or 31 days so they fit into one year.",
                    PostedOn = DateTime.Now,
                });

                Group group2 = new Group();
                group2.Name = "Cars";
                group2.Stories.Add(new Story()
                {
                    Title = "BMW",
                    Description = "This article is about the German automobile and motorcycle manufacturer. For other uses, see BMW (disambiguation).",
                    Content = "BMW's first significant aircraft engine (and commercial product of any sort) was the BMW IIIa inline-six liquid-cooled engine of 1918, much preferred for its high-altitude performance.[9] With German rearmament in the 1930s, the company again began producing aircraft engines for the Luftwaffe. Among its successful World War II engine designs were the BMW 132 and BMW 801 air-cooled radial engines, and the pioneering BMW 003 axial-flow turbojet, which powered the tiny, 1944–1945–era jet-powered 'emergency fighter', the Heinkel He 162 Spatz. The BMW 003 jet engine was first tested as a prime powerplant in the first prototype of the Messerschmitt Me 262, the Me 262 V1, but in 1942 tests the BMW prototype engines failed on takeoff with only the standby Junkers Jumo 210 nose-mounted piston engine powering it to a safe landing.[10][11] The few Me 262 A-1b test examples built used the more developed version of the 003 jet, recording an official top speed of 800 km/h (497 mph). The first-ever four-jet aircraft ever flown, the sixth and eighth prototypes of the Arado Ar 234 jet reconnaissance-bomber, used BMW 003 jets for power. The improving reliability of the 003 as 1944 progressed, earmarked it as the required powerplant for airframe designs competing for the Jägernotprogramm's light fighter production contract, won by the Heinkel He 162 Spatz design. The BMW 003 aviation turbojet also found itself under consideration as the basic starting point for a pioneering turboshaft powerplant for German armored fighting vehicles in 1944–45, as the GT 101.[12] Towards the end of the Third Reich BMW developed some military aircraft projects for the Luftwaffe, the BMW Strahlbomber, the BMW Schnellbomber and the BMW Strahljäger, but none of them were built",
                    PostedOn = DateTime.Now,
                });
                group2.Stories.Add(new Story()
                {
                    Title = "Audi",
                    Description = "Audi RS4 quattro",
                    Content = "The original B5 Audi RS 4 Avant quattro (Typ 8D)[2] was introduced by Audi in late 1999, for main production and sale from 2000, as the successor to the Porsche / quattro GmbH joint venture-developed Audi RS2 Avant. The vehicle, like its RS2 predecessor, was available only as an Avant and was built on an existing platform, in this case the Volkswagen Group B5 platform shared with the A4 and S4. Retail price was around DM 103,584. The RS 4 was available for sale in most of Europe, parts of Asia and in some Latin American countries.",
                    PostedOn = DateTime.Now,
                });
                context.Groups.AddOrUpdate(group1,group2);

            }
           

        }
       
    }
}
