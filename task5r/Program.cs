﻿using System;
using System.Numerics;
using System.Diagnostics;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            HugeInteger h1 = new HugeInteger("476914796134666236301825281227691241134474621043394087818275768911914506422315347259376870106819225299456860317082527213310907303509855855476484541285855594730868217252660920224263417830804958939696689300372903565001336612224447115795154881740747284159955332834113300650377805012799172278327996181593333539874466937854764701081103976764624178897829183568567223329823363620423261064860270596464048583606423302627736585021398818704742409188233725898265845372667180276802758400517881366965533431542010284694908996611352551966426162250103239479801052870046817353291065191517021496367245735557993248559980824549105693001287394182560868625063129625314319594035967108012310904399380358578135587703293964659488133939598212161766296631947941051313042115901703733907616668236530881395674171021105443807246734456429850511593239558191991979714028464877965247763746398058177400283219923373644709990149049540355388825823522723461860787105035112182946875951324106716513403610131710454274324208357367002187171191813062353775572783773574194985076388466511327958062791587782812274410405367589582994382441462799131007449083122978389911787896624154022836309667267895810086884181333383037764082415091316727796227040150331564259194867884241604924743007361420333864290854989740837860820120218666280793985266951532732543532398345618850651784703961043152465055859962379262703019296506825431167690474942108388586064281613162899698339393506673053232957806722852069458580984852855426240810700756140247125855018950027452957574599105490537145912865427822721548375421110547487675147917798738805120182350888517668822419700555239212183472154487696917702644801679294660592174378517650557777089930812304888213566763098038879437916454749679686210204244980879490236808094780505684674511480854859336481130154554233428293613540523878496757243128240671755022284778797577593305982610486124550634003268426964785787176756486845512773105329170526179556650207833913647217613952773452332761012244060707330778756784525599801117641460943944544991996096787479805160472237501231506724005236661275226188819243574912186053983719073395618488336376159612388203576897118515016785839072328364892616213427171209521672198378814342097750251067359853595686113324539723333169135621021201180831662059577342576903763974879616560250543852516141017914687566041949988755703379223894047313109929123003357336881258879300712965115620182070116059434005187593802790692995801531233000514376257983844917849862986664751482029976907160149347368585749902378169142579820415612571355070251505868346930511822726024326089896050648869771969946090607438371589766498652303842423443238371585088596243863070859776880725000680027290934131046710790774007714915284336404864294653645013710014825974868312280298049472847596641417942743598469592760477199882827637224038451026486476430536860013050471113245971932795606929394811670967799939352777414138640995906288796543061449632169926672984603315362541077542647683218385147608827988475761583173830546168352535993580169948634511138376718076325301721274852810747152267969292270838518998214249612497061345922841510623051205624176414901412068146851670197218189932288793578850492269663593467704122897236782916298069389471947706253457974564279064362686316933950190714998540060390956331369674724246892876513488287302647159236870936020369536803180419732454008513517908646223519761557934579253803865719027875664927709201021819225600621600805053126321457644661684642998120615980854385593074336224572659907556676065524211507395065971352515578560082562561521414188906528426766920999038594223247686543010866244997400118757157347302212353042432973689270482667489215606292510950557055144703884422935158069139539570836670845731111565019965392750455589740323327639622468523996775239812293745308246633484926777732675138662431483952692924677853734240312706058651146698377092977927600144210829414370349494959811201209328195568842023135120945082030513848880568547270549859141796344578641890158384834133377563319167971478323255351289480692892995737591405594567137576747752886332174409382875292345676449590484272408440994290319398576919345715003");
            HugeInteger h2 = new HugeInteger("2112312");
            // Console.WriteLine(new HugeInteger("10") * new HugeInteger("0"));
            // Console.WriteLine(new HugeInteger("10") / new HugeInteger("0"));
            // Console.WriteLine(h1 * h2);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            h1 /= h2;
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            // Console.WriteLine(h1);
            // Console.WriteLine(h1 % h2);
            // Console.WriteLine(h1 + h2);
            // Console.WriteLine(h1 - h2);
            // Console.WriteLine(h1 > h2);
            // Console.WriteLine(h1 < h2);
            // Console.WriteLine(h1 == h2);
            // Console.WriteLine(h1 >= h2);
            // Console.WriteLine(h1 <= h2);
            // Console.WriteLine(h1 != h2);
        }
    }
}