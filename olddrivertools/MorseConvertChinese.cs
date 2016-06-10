﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace olddrivertools
{
    static class MorseConvertChinese
    {
        static System.Collections.Generic.Dictionary<char, string> morseCode = new Dictionary<char, string>();
        /// <summary>
        /// 转化为半角字符串（扩展方法）
        /// </summary>
        /// <param name="input">要转化的字符串</param>
        /// <returns>半角字符串</returns>
        public static string ToSBC(this string input)//single byte charactor
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)//全角空格为12288，半角空格为32
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)//其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

        /// <summary>
        /// 转化为全角字符串（扩展方法）
        /// </summary>
        /// <param name="input">要转化的字符串</param>
        /// <returns>全角字符串</returns>
public static string ToDBC(this string input)//doublebytecharactor
{
char[]c=input.ToCharArray();
for(int i=0;i<c.Length;i++)
{
if(c[i]==32)
{
c[i]=(char)12288;
continue;
}
if(c[i]<127)
c[i]=(char)(c[i]+65248);
}
return new string(c);
}
const string yuan="、9977。9975·9978·9992·9993-9994-9995…9991'9984'9985\"9986\"9987《9996》9997×9973×9999÷9974□9998Ⅰ9941Ⅱ9942Ⅲ9943Ⅳ9944Ⅴ9945Ⅵ9946Ⅶ9947Ⅷ9948Ⅸ9949Ⅹ9950！9982（9988）9989＋9971，9976－9972／9970０9960１9961２9962３9963４9964５9965６9966７9967８9968９9969：9980；9979＝9983？9981Ａ9874Ｂ9875Ｃ9876Ｄ9877Ｅ9878Ｆ9879Ｇ9880Ｈ9881Ｉ9882Ｊ9883Ｋ9884Ｌ9885Ｍ9886Ｎ9887Ｏ9888Ｏ9800Ｐ9889Ｑ9890Ｒ9891Ｓ9892Ｔ9893Ｕ9894Ｖ9895Ｗ9896Ｘ9897Ｙ9898Ｚ9899Ω9959А9768Б9769В9770Г9771Д9772Е9773Ж9774З9775И9776Й9799К9777Л9778М9779Н9780О9781П9782Р9783С9784Т9785У9786Ф9787Х9788Ц9789Ч9790Ш9791Щ9792Ъ9796Ы9797Ь9798Э9793Ю9794Я9795ㄅ9720ㄆ9721ㄇ9722ㄈ9723ㄉ9724ㄊ9725ㄋ9726ㄌ9727ㄍ9728ㄎ9729ㄏ9730ㄐ9731ㄑ9732ㄒ9733ㄓ9734ㄔ9735ㄕ9736ㄖ9737ㄗ9738ㄘ9739ㄙ9740ㄚ9744ㄛ9745ㄜ9746ㄝ9747ㄞ9748ㄟ9749ㄠ9750ㄡ9751ㄢ9752ㄣ9753ㄤ9754ㄥ9755ㄦ9756ㄧ9741ㄨ9742ㄩ9743━9990啊0759阿7093埃1002挨2179哎0740唉0780哀0755皑4114癌4074蔼5676矮4253艾5337碍4293爱1947隘7137鞍7254氨8637安1344俺0219按2174暗2542岸1489胺5143案2714肮7542昂2491盎4138凹0425敖2407熬3581翱5063袄5984傲0277奥1159懊2020澳3421芭5359捌2193扒2091叭0665吧0721笆4576八9908八9808八0360八9708疤4002巴1572拔2149跋6405靶7249把2116耙5090坝8218坝1056霸7218霸6011罢5007爸3640白4101柏2672百4102摆2369佰0184败2408拜2157稗4458斑2432班3803搬2289扳2104般5301颁7317板2647版3652扮2101拌2142伴0133瓣3904半0584办6586绊4810邦6721帮1620梆2735榜2831膀5218绑4834棒2761磅4319蚌5732镑6967傍0266谤6196苞5383胞5165包0545褒5988剥0475薄5631雹7192保0202堡1027饱7394宝1405抱2128报1032暴2552豹6283鲍7637爆3915爆3615杯2637碑4301悲1896卑0585北0554辈6543背5154贝6296倍0223狈3709备0271惫1994焙3538被5926奔1149苯0058本2609笨4570崩1514绷4855甭8005泵3119蹦6498迸6618逼6656鼻7865比3024鄙6766笔4581彼1764碧4310蓖5557蔽5599毕3968毙2426毖3025币1578庇1642痹4036闭7028敝2411弊1705必1801辟6582壁1084臂5242避6699陛7103鞭7267边6708编4882贬6312扁2078便0189变6239卞0593辨6587辩6589辫4947遍6664标2871彪1753膘9136表5903鳖7667别0446瘪4085彬1755斌2430濒3464滨3453宾6333摈2363兵0365冰0393柄2671丙0014秉4426饼7399炳3521病4016并1629玻3788菠5474播2330拨2328钵6886波3134博0590勃0514搏2276铂6896箔4613伯0130帛1591舶5306脖9126膊5225渤3258泊3124驳7463捕2198卜0592哺0773补5943埠1009不0008布1580步2975簿4689部6752怖1831擦2361猜3719裁5932材2624才2088财6299睬4174踩6425采6846采6845彩1752菜5475蔡5591餐7404参0639蚕5729残2995惭1974惨1971灿3503灿3605苍5547舱5319仓0221沧3318藏5661操2347糙4751槽2864曹2580草5430厕0527厕0627策4595侧0258册0374测3261层1461蹭6479插2252叉2096叉0643茬9173茶5420查2686碴4329搽2258察1390岔1479差1567诧6109拆2135柴2693豺6284搀2356掺2296蝉5848馋7443谗6243缠4961铲6980产3934阐7073颤7358昌2490猖3715场1034尝0863常1603长7022偿0326肠5214厂0617敞2412畅2545唱0788倡0235超6389抄2113钞6872朝2600嘲0877潮3390巢1560吵0703炒3509车6508扯2102撤2327掣2233彻1796澈3400郴6754臣5256辰6591尘1057晨2525忱1820沉3089陈7115趁6387衬6000撑2319撑2300称4468城1004橙2892成2052呈0701乘0042程4453惩2033澄3397诚6134承2110逞6642骋7488秤4439吃0676痴4035持2170匙0555池3069迟6688弛1716驰7459耻5103齿7876侈0172尺1439赤6375翅5041斥2444炽3589充0339冲0394虫5722崇1504宠1404抽2132酬6804畴3985踌6486稠4464愁1935筹4693仇0092绸4846瞅4197丑0010臭5263初0443出0427橱8599厨1676躇6484锄6915雏7176滁3315除7110楚2806础4342储0328矗4238搐2294触6051处5710揣2260川1557穿4502椽2796传0278船5307喘0820串0025疮4056窗4514幢1617床1643闯7068创0482吹0706炊3507捶2211锤6925垂0987春2504椿2797醇6815唇0782淳8708淳3196纯4783蠢5868戳2067绰4862疵4009茨5412磁4318雌7166辞6588慈1964瓷8851瓷3911词6101此2974刺0459赐6337次2945聪5115葱5523囱0935匆8116从1783丛0654凑0410粗4723醋6818簇4662促0191蹿4533篡4647摧2301崔1508催0275脆5186瘁4041粹4733淬3231翠5050村2625存1317寸1407磋4322撮2331搓2238搓2278措2181错2290错6934搭6671达4594答4079瘩2092打1129大0714呆2983傣2071傣7831戴1601带2990代6313代0108贷5915待1769待6649怠5104怠1836耽2137丹0830丹0030单6779郸8473掸9116胆2481氮8644但0141惮1998淡3225诞6130弹1734蛋5751当3981挡2346党7825党8093荡5616档2909刀0430捣2281蹈6457倒0227岛1497祷4411导1418到0451稻4470悼1902道6670盗4142德1795得1779的4104蹬6478灯3597登4098等4583瞪4223凳0419邓6772堤1029低0144滴3336迪6611敌2420笛4564狄3695涤3321翟5049嫡1279抵2107底1646地0966蒂5530第4574帝1593弟1717递6677缔4877颠7351掂2195滇3329碘4290点7820典0368靛7233垫1067电7193佃0140甸3949店1648惦1855奠1156淀3244殿3013碉4306雕7171凋0406刁0431掉2220吊0680钓6860调6148跌6407爹3638碟4308蝶5805迭6613谍6183叠0655丁0002盯4169叮0666钉6857顶7307鼎7844锭6928定1353订6057丢0016东2639冬0392董5516懂2016动0520栋2767侗0179恫1871冻0408洞3159兜0351抖2122斗2435陡7107豆6258逗6637痘4026都6757督4206毒3021犊3685独3747读6236堵1035睹4212赌6350杜2629镀6947肚5137度1653渡3256妒1176端4551短4252锻6939段3008断2451缎4876堆1018兑0345队7130对1417墩1076吨0903蹲6472敦2415顿7319囤0937钝6868盾4163遁6658掇2218哆8135多1122夺1161垛1000躲6503朵2614跺1118舵5305剁0449惰1924堕1077蛾5760峨1494鹅7709俄0192额7345讹6073娥1230恶1921厄0618扼2108遏6666鄂6759饿7408恩1869儿0334儿0348耳5101尔1422饵7403洱3167二5079二0059二9902二9802二9702贰1708发4099罚5000筏4589伐0127乏0040阀7042法3127珐8828藩5672帆1581番3972翻5064樊2868矾4345钒9440钒5440繁4907凡0416烦3565反0646返6604范5400贩6305犯3690饭7391泛3131坊0972芳5364方2455肪9112房2075防7089妨1186仿0119访6078纺4791放2397菲5481非7236啡0803飞7378肥5142匪0564诽6145吠0693肺5151废1683沸3110费6316芬5358酚1568吩0695氛3050分0433纷4788坟0970焚3539汾3083粉4720奋1164份0118忿1825愤2001粪4747丰0023封1409枫2800蜂5762峰1496锋6912风7364疯4045烽3536逢6646冯7458缝4911讽6174奉1144凤7685佛0154否0694夫1133敷2421肤5227孵1335扶2105拂2133辐6553幅1607氟8636符4569伏0126俘0199服2591浮3187涪3242福4395袱5931弗1715甫3940抚2329辅6534俯0214釜6858斧2445脯5194腑5202府1650腐5201赴6384覆6010赋6346复1788傅0265付0479付0102阜7079父3637腹5215负6298富1381讣6058附7096妇1244缚4902咐0696噶0900嘎0867该6115改2395概2861钙6862盖5556溉3346干1626甘3927杆2616柑2674竿4557肝5139赶6385感1949秆4427敢2413赣6373冈1481刚0474钢6921缸4971肛5138纲4854岗1511港3263杠8530篙4643皋4108高7559膏5221羔5021糕4741搞2269镐6964稿4473告0707哥0766歌2960搁2364戈2047鸽7704胳5163疙4095割0480革7245葛5514格2706蛤5756阁7041隔7133铬9459个0020各0677给4822根2704跟6418耕5087更2577庚1649羹5036埂8217耿5105梗2739工1562攻2396功0501恭1872龚7895供0180躬6501公0361宫1362弓1712巩7255汞3074拱2162贡6300共0364钩6869勾0551沟3297苟5384狗3699垢0996构2845购6356够1124辜6581菇5466咕0734箍4611估0131沽3114孤1324姑1196鼓7849古0657蛊5872骨7539谷6253股5140故2399顾7357固0942雇7163刮0450瓜3900剐0478寡1391挂2171褂5962乖0041拐2145怪1843棺2778关7070官1351冠0385观6034管4619馆7419罐4984惯1977灌3487贯6306光0342广1639逛6640瑰3855规6016圭0964硅8944归2981龟7898闺7043轨6510鬼7607诡6111癸4097桂2710柜2681跪6422贵6311刽0492辊6547滚3340棍2760锅6938郭6753国0948果2654裹5955过6665哈0761骸7546孩1326海3189氦8640亥0075害1364骇7480酣6799憨2003邯6725韩7281含0698涵3211寒1383函0428喊0815罕4988翰5060撼2338捍2194旱2487憾2013悍1880焊3549汗3063汉3352夯1137杭2635航5300壕1091嚎0866豪6275毫3032郝6787好1170耗5088号5714浩3185呵0725喝0824菏3235核2702禾4421和0735何0149合0678盒4139貉6288阂7039河3109涸3212赫6378褐5964鹤7729贺6320嘿0884黑7815痕4024很1771狠3703恨1868哼0774亨0077横2897衡5899恒1854轰6575哄0758烘3530虹5725鸿7703洪3163宏1347弘1738红4767喉0814侯0186猴3729吼0709厚0624候0230后0683呼0729乎0039忽1824瑚3840壶1106葫5519胡5170蝴5814狐3698糊4739湖3275弧1721虎5706唬0801护6233互0062沪3337户2073花5363哗0873华5478猾3736滑3323画3937画3973划0439化0553话6114槐2849徊1773怀2037淮3232坏0975欢2970环3883桓2719还6703缓4883换2255患1891唤0822痪4050豢6273焕3562涣3251宦1360幻1634荒5435慌1967黄7806磺4337蝗5794簧4679皇4106凰0420惶1929煌3552晃2515幌1610恍1857谎6192灰3500挥2264辉6540徽1798恢1863蛔5784回0932毁3014悔1882慧1979卉0583惠1920晦2526贿6325秽4486会2585烩2476汇0565讳6172诲6140绘4940荤5526昏2495婚1241魂3268浑7609混3236豁6255活3172伙0129火3499获3752或2057惑1910霍7202货6303祸4393击2345圾0969基1015机2623畸3982稽4472积4480箕4614肌5133饥7382迹6619激3423讥6217鸡7741姬1213绩4921缉4874吉0679极2817棘2765辑6549籍4694集7162及0644急1838疾4014汲0378汲3078即0613嫉1271级4878级4787挤2357几0415脊5182己1569蓟5636技2111冀0370季1323伎0125祭4385剂0495悸1900济3444寄1376寂1374计6060记6068既2478忌1803际7139妓1178继4949纪4764嘉0857枷2666夹1140佳0163家1367加0502荚5453颊7335贾6328甲3946钾6905假0250稼4471价0116架2665驾7468嫁1268歼3005监4148坚1017尖1423笺4608间7035煎3553兼0369肩5144艰5329奸1169缄4873茧4942检2914柬2687碱4354硷7769硷8969拣2245简4675俭0313剪0477减8096荐5433槛2920鉴7003践6432贱6345见6015键6943箭4628件0115健0256舰5324剑0494饯7415渐3362溅3457涧3386建1696僵0304姜1302姜1203将1412浆3364江3068疆3984蒋5592桨2862奖1162讲6199匠0561酱6830降7100蕉5604椒2786礁4339焦3542胶5231交0074郊6738浇3398骄7524娇1293嚼0920搅2383铰6890矫4255侥0299脚5183狡3701角6037饺7398缴4945绞4819剿0485剿8464教2403酵6806轿6569较6525叫0663窖4512揭2263接2234皆4105秸4447街5894阶7132截2066劫0506节4634桔2720杰0267杰2638捷2212睫4208竭4550洁3381结4814解6043姐1195戒2054藉5659芥5354界3954借0234介0094疥4003诫6135届1447巾1577筋4585斤2443金6855今0093津3160襟5992襟5995紧4868锦6930仅0284谨6310谨6210进6651靳7246晋2516禁4391近6602烬3612浸3190尽4147劲0513荆5427兢0352茎5449睛4200晶2533鲸7650京0079惊7528精4737粳4734经4842井0064警6224警6226景2529颈7338静7234境1064敬2417镜6975径1777痉3997靖7231竟4552竞4544净0403炯3518窘4515揪2262究4496纠4763玖3773韭7295久0036灸3502九9909九9709九9809九0046酒6794厩1673救2405旧5283臼5273舅5279咎0736就1432疚3998鞠7263拘2153狙3700疽4013居1446驹7467菊5468局1444咀0731矩4251举5282沮3107聚5112拒2147据2207巨1565具0367距6415踞6436锯6920俱0215句0658惧2040炬3515剧0489捐2196鹃7710娟1227倦0239眷4187卷0608绢4831撅2313攫2384抉2115掘2228倔8056爵3635觉6030决0414决6076绝4815均0971菌5497钧6874军6511君0689峻1498俊0193竣4546浚3182郡6746骏7486喀0807咖0739卡0595咯0748开7030揩2261楷2818凯0418慨1980刊0436堪1030勘0522坎0974砍4266看4170康1660慷1988糠4749扛2095抗2123亢0073炕3510考5072拷2166烤3628靠7237坷0985苛5381柯2688棵2644磕4326颗7341科4430壳8199咳0750可0668渴3265克0344刻0466客1356课6143肯5146啃8186垦1083恳2017坑0977吭0699空4500恐1858孔1313控2235抠2305口0656扣2099寇1379枯2661哭0770窟4516苦5388酷6807库1655裤5974夸1139垮1006挎2175跨6421胯5169块1040筷4599侩0312快1816宽1401款2949匡0562筐4590狂3693框2713矿4349眶4186旷2568况0400亏5719盔4140岿8354窥4529葵5525奎1145魁7608傀0264馈7432愧1951溃3391坤0981昆2492捆2190困0938括2161扩2368廓1674阔7059垃0998拉2139喇0812蜡5779腊5198辣6584啦0784莱5490来0171赖6351蓝5663婪1245栏2936拦2374篮4691阑7061兰5695澜3482谰9301揽2385览6031懒2036缆4968烂3620滥3448琅3809榔2826狼3708廊1671郎6745朗2597浪3186捞2318劳0525牢3666老5071佬0097姥1209酪6803烙3529涝3399勒0519乐2867雷7191镭7012蕾5628磊4320累4797儡8079垒1093擂2341肋5132类7352泪3223棱2789楞2807冷0397厘0622梨2746犁3680黎7812篱4713狸3706离7180离4418漓3347理3810李2621里6849鲤7642礼4409莉5461荔5408吏0684栗2698丽7787厉0632励0536砾4351历2980利0448傈0269例0173俐0196痢4031立4539粒4721沥3468隶7152力0500璃3863哩0769哩5070俩0224联5114莲5571连6647镰6991廉1670怜1995涟3353帘1588敛2425脸5245链6969恋2043炼3550练4886粮9037凉0404凉3213梁2733粱4731良5328两0357辆6538量6852晾8512亮0081谅6156撩2316聊5108僚0297疗4070燎3598寥1394辽6697潦3388了0055撂2297镣9507廖1675料2436列0441裂5933烈3525劣0503猎3756琳3829林2651磷4340霖7207临5259邻6775鳞7673淋3218凛0412赁6324吝0690拎2146玲3781菱5480零7190龄7881铃6875伶0134羚5024凌0407灵7227陵7117岭1545领7325另0659令0109溜3296琉3812榴2839硫4288馏5130留3966刘0491瘤4058流3177柳2692六9706六0362六9906六9806龙7893聋5122咙0918笼4705窿9002隆7127垄1096拢2379陇7150楼2869娄1236搂2299篓4664漏3345陋7097芦5684卢4151颅7361庐1687炉3619掳2342卤7767虏5712鲁7627麓7785碌4294露7216路6424赂6323鹿7773潞3406禄4389录6922陆7120戮2068驴7533吕0712铝6986侣0188旅2464履1462屡1459缕4917虑1982氯3048律1774率3764滤3459绿4845峦1551挛2381孪1334滦3497卵0607乱0052掠2230略3970抡2241轮6544伦0243仑0178沦3229纶4858论6158萝5700螺5828罗5012逻6709锣7017箩4712骡7512裸4387裸5953落5507洛3157骆7482络4820妈1265麻4034麻7802玛3854码4316蚂5818马7456骂5006嘛0859吗0834埋1003买6314麦7796卖6344迈6701脉9115瞒4221馒7429蛮5875满3341蔓5585曼2581慢1976漫3355谩6211芒5345茫5413盲4159氓3047忙1811莽5462猫3728茅5403锚6931毛3029矛4243铆9450卯0602茂5399冒0379帽1604貌6290贸6319么8010玫3780枚2653梅2734酶5326霉7199煤3561没3093眉4168媒1252镁9485每3020美5019昧2505寐1382妹1188媚1253门7591门7024闷1899们0226萌5492蒙5536檬2916盟4145锰7021猛3718梦1125孟1322眯4183醚5721靡7238糜4745迷6617谜6193弥1736米4717秘4434觅6017泌3125蜜5778密1378幂0389棉2758棉7258眠4177绵4875冕0380免0346勉0517娩1231缅4884面7240苗5379描2249瞄4178藐5662秒4432渺3267庙1680妙1181蔑5583灭3319民3046抿2129皿4129敏2404悯2006闽7044明2494螟5820鸣7686铭6900名0682命0730谬6208摸2307摹2308蘑5704模2875膜5229磨4333摩2302魔7621抹2130末2608莫5459墨1075默7817沫3106漠3351寞1389陌7099谋6180牟3664某2673拇2136牡3665亩3965姆1191母3018墓1045暮2550幕1612募0927慕1970木2606目4158睦4207牧3668穆4476拿2169哪0763呐0704钠6871那6719娜1226纳4780氖6036乃0035奶1168耐5082奈1143南0589男3948难7181囊0926挠2321脑5207恼1925闹9527闹7593淖8681呢0716馁7407内0355嫩1282能5174妮1200霓7206倪0242泥3136尼1441拟2362你0132匿0574腻5232逆6627溺3312蔫5576拈2138年1628碾4317撵2365捻2214念1819娘1224酿6840鸟7680尿1443捏2250聂5119孽5642啮0909镊7015镊7105镍6996涅3206您1849柠2899狞3761狞3461凝0413宁1337拧2349泞3438牛3662扭2100钮6873纽4781脓5240浓3426农3593农6593弄1702奴1167努0505怒1829女1166暖2541虐5707疟4061挪2180懦2032糯4754诺6179欧2962鸥7743殴3016藕5665呕0868偶0260沤3371爬3632帕1584怕1830琶3831拍2143排2226牌3654徘1780湃3269派3175攀2372潘3382盘4149磐4323盼4162畔3961判0445叛0651乓8004庞1690旁2460耪6590胖5160抛2141咆0733刨0442炮3517袍5916跑6410泡3133胚5162培1014裴5952赔6341陪7111配6792佩0160沛3099喷0899盆4133砰4280抨2125烹3534澎3403彭1756蓬5570棚2766硼4296篷4659膨5191朋2590鹏7720捧2201碰4314坯0999砒4268霹7219批2106披2126劈0490琵3832毗3026啤0802脾5196疲4006皮4122匹0572痞4028僻0306屁1445譬6229篇4638偏0252片3651骗7499飘7373漂3343瓢3903票4384撇2317瞥4224拼2178频7340贫6302品0756聘5111乒8003坪0988苹5393萍5493平1627凭0417瓶3910评6097屏1456坡0980泼3380颇7324婆1237破4275魄7611迫6612粕4722剖0472扑2090铺6917仆0091莆5455葡5515菩5476蒲5543埔1033朴2613圃0944普2528浦3184谱6225曝2566瀑3462期2601欺2952栖2722戚2058妻1189七9707七9807七9907七0003凄0401漆3344柒2675其0366棋2759奇1142歧2978畦3971崎1505脐5247齐7871旗2475祈4362祁4359骑7494起6386岂6259乞0047企0120启0796契1148砌4265器0892气3049迄6597弃2757汽3086泣3135讫6066掐2225恰1874洽3174牵3677扦8422钎7244铅6884千0578迁6692签4687仟0107谦6197乾0051黔7816钱6929钳6883前0467潜3383遣6680浅3239谴6232堑1058嵌1523欠2944歉2959枪2847呛0850腔5204羌5018墙8255蔷5638强1730抢2293橇8587锹6942敲2418悄1877桥2890瞧4225乔0821乔0829侨0294巧1564撬2334翘5062峭1495俏0195窍4534切0434茄5401且0011怯1845窃4537钦2953侵0187亲6024秦4440琴3830勤0530芹5367擒2350禽4419寝1392沁3084青7230轻6535氢8641倾0282卿0615清3237擎2348晴2532氰8642情1906顷7308请6153庆1987琼8825穷4522秋4428丘8002邱6726球3808求3061囚0933酋6790泅3120趋6395区0575蛆5747曲2575躯6504屈1448驱7517渠3255取0648娶1235龋7889趣6393去0637圈0946颧7362权2938醛7379泉3123全0356痊4019拳2164犬3689券0457劝0538缺4972炔7448瘸4063却0606鹊7717榷2854确4292雀7158裙5942群5028然3544燃3595冉0373染2676瓤3905壤1099攘2376嚷0924让6245饶7437扰2371绕4935惹1931热3583壬1103仁0088人0086忍1804韧7282任0117认6126刃0432妊1175纫4771扔2093仍0095日2480戎2051茸5422蓉5554荣2837融5816熔3579溶3310容1369绒4823冗0383揉2248柔2677肉5131茹5423蠕5862儒0320孺1332如1172辱6592乳0050汝3067入0354褥5970软6516阮7086蕊5605瑞3843锐6904闰7032润3387若5387弱1726撒2320洒3155萨5646腮5210鳃7658塞1049赛6357三9903三0005三9803三9703叁0638伞0270散2414桑2718嗓0837丧0828搔2279骚7510扫2217嫂1269瑟3844色5331涩3396森2773僧0300莎5446砂4263杀3010刹0458沙3097纱4784傻0247啥0798煞3559筛4652晒2488珊3790苫5390杉2619山1472删0444煽3569衫5904闪7026陕7104擅2343赡6365膳5234善0810汕3073扇2271扇2082缮4931墒8262伤0281商0794赏6339晌2517上0006尚1424裳5951梢2744捎2200稍4455烧3599芍5342勺0541韶7300少1421哨0783邵6730绍4801奢1158赊6332蛇5748舌5286舍5287赦6376摄2378射1410慑2042涉3195社4357设6080砷8938申3947呻0728伸0135身6500深3234娠1228绅4800神4377沈3088审1399婶1306甚3928肾5200慎1957渗3334声5116生3932甥3935牲3673升0581绳4939省4164盛4141剩0476胜0524圣5110师1597失1136狮3740施2457湿3440诗6108尸1437虱5723十9813十9814十9815十9816十9817十9818十9819十0577十9710十9711十9712十9910十9911十9912十9913十9914十9915十9916十9917十9918十9919十9810十9811十9812石4258拾2168时2514什0087食7380蚀5793实1395识6221史0670矢4247使0169屎1452驶7471始1193式1709示4355士1102世0013柿2636事0057拭2160誓6129逝6641势0528是2508嗜0841噬0896适6624仕0099侍0174释6847饰7395氏3044市1579恃1853室1358视6018试6107收2392手2087首7445守1343寿1108授2219售0786受0649瘦4060兽3757蔬5600枢2873梳2752殊2992抒2118输6551叔0647舒5289淑3219疏3990书2579赎6370孰1328熟3578薯5620暑2540曙2562署5002蜀5771黍7810鼠7857属1466术2611述6615树2885束2631戍2050竖4549墅1065庶1659数2422漱3359恕1859刷0456耍5080摔2292衰5905甩3943帅1596栓2633拴2165霜7208双7175爽3642谁6142水3055睡4204税4451吮0700瞬4226顺7311舜5293说6141硕4311朔2592烁3617斯2448撕2322嘶0880思1835私4424司0674丝4828死2984肆5127寺1408嗣0843四0934四9804四9904四9704伺0136似0138饲7393巳1570松2646耸5117怂1981颂7313送6623宋1345讼6075诵6139搜2282艘5318擞2370嗽0870苏5685酥6798俗0198素4790速6643粟4725僳0287塑1043溯3307宿1372诉6083肃5126酸6808蒜5537算4615虽7173隋7131随7151绥4840髓7557碎4295岁2979穗4482遂6659隧7143祟4378孙1327损2275笋4571蓑5560梭2747唆0778缩4799琐3851索4792锁6956所2076塌1042他0100它1338她1247塔1044獭3758挞2337蹋6488踏6431胎5158苔5377抬2127台0669泰3141酞6811太1132态1966汰3077坍0973摊2382贪6304瘫4093滩3492坛1086檀2905痰4033潭3389谭6223谈6151坦0982毯3034袒5917碳8955探2232叹0855炭3516汤3282塘1048搪2288堂1016棠2768膛5228唐0781糖4743倘0229躺6507淌3358趟6396烫3594掏2223涛3447滔3325绦4969萄5426桃2711逃6625淘3221陶7118讨6062套1152特3676藤5671藤5971腾7506疼4012誊6187梯2748剔0471踢6437锑6982提2251题7344蹄6452啼0805体7555替2583嚏0908惕1912涕3199剃0461屉1449天1131添3240填1050田3944甜3929恬1815舔7897腆5197挑2176条2742迢6606眺4189跳6426贴6317铁6993帖1586厅1689听8126烃7899汀3060廷1694停0089停0255亭0080庭1656挺2185艇5312通6639桐2717酮7904瞳4227同0681铜6894彤1749童4547桶2729捅2183筒4592统4827痛4027偷0262投2121头7333透6631凸0424秃4422突4499图0956徒1778途6634涂3205屠1458土0960吐0685兔0347湍3273团0957推2236颓7339腿5217蜕5770褪5963退6622吞0691屯1470臀5241拖2151托2094脱5192鸵9676陀7094驮7461驼7474椭2900妥1185拓2148唾0790挖2177哇0760蛙5752洼3173娃1216瓦3907袜5920歪2977外1120豌6261弯1737湾3494玩3779顽7316丸0029烷7909完1346碗4297挽2187晚2519皖4111惋1923宛1354婉1238万8001腕5205汪3076王3769亡0072枉2648网4986往1766旺2489望2598忘1808妄1174威1218巍1550微1792危0604韦7279违6672桅2712围0953唯0787惟1919为3634潍3452维4850苇5517萎5494委1201伟0251伪0298尾1442纬4885未2607蔚5588味0724畏3956胃5152喂0808魏7614位0143渭3262谓6182尉1414慰1983卫5898瘟4054温3306蚊5730文2429闻5113纹4773吻0708稳4489紊4772问0795嗡0849翁5040瓮3908挝2339蜗5815涡3260窝4519我2053斡2441卧5257握2259沃3087巫1566呜0839钨7005乌3527污3064诬6136屋1450无2477芜5617梧2745吾0710吴0702毋3019武2976五9805五0063五9905五9705捂2158午0582舞5294伍0124侮0185坞1051戊2048雾7212晤2524物3670勿0543务0523悟1889误1888误6137昔2497熙3556析2649西6007硒8970矽8928晰2530嘻0883吸0705锡6932牺3686稀4449息1873希1585悉1885膝5230夕1119惜1917熄3571烯7910溪3305汐3071犀3679檄2907袭6002席1598习5045媳1261喜0823铣6897洗3156系4762隙7138戏2070细4798瞎4219虾5802匣0563霞7209辖6561暇2538峡1499侠0204狭3707下0007厦0633夏1115吓0687掀2216锨9475先0341仙0103鲜7639纤4960咸0752贤6343衔6902舷5304闲7033涎3241弦1720嫌1273显7359险7145现3807献3759县4905腺5177馅7414羡5029宪2009陷7119限7098线4848相4161厢1666镶7013香7449箱4630襄5980湘3276乡6763翔5046祥4382详6116想1927响0742享0078项7309巷1574橡2895像0288向0686象6272萧5618硝4285霄7197削0465哮0771嚣0923销6906消3194宵1366淆3216晓2556小1420孝1321校2699肖5135啸0876笑4562效2400楔2801些0067歇2957蝎5791鞋7256协0588挟2188携2377邪6723斜2438胁5178谐6168写1400械2750卸0609蟹5851懈2018泄3118泻3454谢6200屑1454薪5647芯5361锌6854欣2946辛6580新2450忻1823心1800信0207衅5881星2502腥5206猩3726惺1932兴5281刑0438型0992形1748邢6717行5887醒6821幸1630杏2622性1840姓1198兄0338凶0423胸5172匈0546汹3081雄7160熊3574休0128修0208羞5026朽2615嗅0833锈6907秀4423袖5918绣4836墟1074戌2049需7194虚5711嘘0864须7312徐1776许6079蓄5552酗6796叙0650旭2485序1645畜3964恤1865絮4825婿8296绪4872续4958轩6513喧0826宣1357悬2038旋2467玄3763选6693癣4089眩4181绚4821靴7247薛5641学1331穴4494雪7185血5877勋8113熏3575循1789旬2484询6104寻1416驯7460巡1559殉2991汛3065训6064讯6061逊6676迅6598压1090押2131鸦7693鸭7700呀0711丫0021芽5370牙3660蚜5742崖1509衙5895衙5893涯3209雅7161哑0800亚0068讶6074焉3547咽0754阉7050烟3533淹3238盐7770严0917研4282蜒5783岩1484延1693言6056颜7346阎7051炎3508沿3116奄1141掩2237眼4190衍5888演3348艳5333堰1037燕3601厌0630砚4291雁7159唁0777彦1750焰3543宴1365谚6176验7526殃2988央1135鸯7699秧4441杨2799扬2254佯0162疡4046羊5017洋3152阳7122氧8638仰0111痒4022养7402样2876漾3363邀6700腰5212妖1179瑶3852摇2280尧1031遥6674窑4523谣6202姚1202咬0747舀5276药5522要6008耀5069椰2794噎0888耶5102爷3639野6851冶0396也0048页7306掖2227业2814叶0673曳2576腋5199夜1123液3210一9701一0001一9901一9801壹1105医6829揖2253铱7917依0181伊0122衣5902颐7328夷1138遗6695移4448仪0308胰5166疑3992沂3085宜1355姨1210彝1744椅2783蚁5852倚0231已1571乙0044矣4248以0110艺5669抑2117易2496邑6712屹1473亿0310役1763臆5244逸6654肄5125疫4004亦0076裔5939意1942毅3015忆2011义5030益4135溢3300诣6195诣6105议6231谊6146译6230异8381翼5065翌5043绎4946茵5419荫5593因0936殷3009音7299阴7113姻1215吟0692银6892淫3230寅1377饮7390尹1438引1714隐7148印0603英5391樱2937婴1305鹰7751应2019缨4964莹3853萤5821营3602荧3576蝇5859迎6601赢6366盈4134影1758颖4481硬4289映2503哟0847拥2340佣0096臃5250痈4092庸1661雍7167踊6429蛹5769咏0737泳3144涌8673永3057恿1960勇0516用3938幽1636优0327悠1890忧1992尤1429由3945邮6755铀6914犹3730油3111游3266酉6788有2589友0645右0671佑0147釉6848诱6131又0642幼1635迂6596淤3226于0060盂4130榆2810虞5713愚1946舆5280余0151俞0205逾6661鱼7625愉1938渝3254渔3342隅7126予0056娱1225雨7183屿1546禹4416宇1342语6133羽5038玉3768域1008芋5341郁6735吁0675遇6657喻0827峪1502御1785愈1937欲2948狱3739育5148誉6235浴3188寓1384裕5940预7315豫6276驭7457鸳7696渊3220冤0387元0337垣0997袁5913原0626援2266辕6562园0954员0765圆0955猿3737源3293远6678苑5373愿1959怨1841院7108曰2574约4766越6390跃6460钥7011岳1471粤4727月2588悦1878阅7048耘5089云0061郧6765匀0542陨7134允0336运6663蕴5686酝6824晕2546韵7301孕1314匝0559砸4271杂7177栽2707哉0762灾3506宰1363载6528再0375在0961咱0749攒2380暂2548赞6363赃6368脏5253葬5520遭6685糟4748凿7020枣2764早2483澡5679蚤5734躁6481噪0894造6644皂4103灶3501燥3604责6307择2344则0463泽3419贼6329怎1827增1073憎1999曾2582赠6362扎2089渣3257札2610轧6509铡9484闸7037眨4172栅2694榨2834咋0738乍0038炸3498诈6094摘2298斋7872宅1341窄4504债0280寨1396瞻4232毡3030詹6124粘4724沾3115盏4144斩2447辗6558崭1535展1455蘸5699栈2770占0594战2069站4541湛3277绽4861樟2874章4545彰1757漳3361张1728掌2222涨3360杖2627丈0004帐1600账6348仗0101胀5195瘴4066障7140招2156昭2507找2109沼3113赵6392照3564罩4996兆0340肇5128召0664遮6686折2124哲0772蛰5832辙6568者5074锗7926蔗5587这6638浙3181珍3791斟2440真4176甄3914砧4278臻5271贞6297针6859侦0259枕2650疹4011诊6085震7201振2182镇6966阵7109蒸5544挣2197睁4201征1767狰3717争3630怔1850整2419拯2163正2973政2398帧1608症4017郑6774证6086芝5347枝2655支2388吱8123蜘5776知4249肢5141脂5176汁3059之0037织4930职5120直4160植2784殖2994执1013值0237侄1212址0968指2172止2972趾6400只0662旨2482纸4786志1807挚2304掷2367至5267致5268置4999帜1615峙1492制0455智2535秩4442稚4460质6347炙3511痔4023滞3333治3112窒4510中0022盅4132忠1813钟6988衷5907终4807种4429肿5209重6850仲0112众5883舟5297周0719州1558洲3166诌6188粥4728轴6519肘5136帚1590咒0720皱4126宙1352昼2521骤7532珠3796株2701蛛5753朱2612猪3727诸6175诛6121逐6632竹4554烛3608煮3554拄2134瞩4241嘱0928主0031著5511柱2691助0504蛀5746贮6308铸6999筑4591住0145注3137祝4376驻7465抓2119爪3629拽2167专1413砖4331转6567撰2332赚6354篆4637桩2866装5944妆1182撞2326壮1104状3692椎2785锥6923追6620赘6361坠1071缀4856谆6150准0402捉2191拙2154卓0587桌2715琢3820茁5398酌6791啄0793着4192灼3504浊3424兹5417咨0745资6327姿1217滋3320淄3245孜1320紫4793仔0098籽4750滓3324子1311自5261渍3356字1316鬃7571棕2762踪9338宗1350综4844总4920纵4912邹6760走6382奏1146揍2213租4436足6398卒0586族2469祖4371诅6100阻7091组4809钻9449纂4951嘴0878醉6816最2584罪4997尊1415遵6690昨2506左1563佐0146柞2683做0254作0155坐0976座1654亍8015丌8000兀0335丐0009廿0579廿9820廿9821廿9920廿9921廿9922廿9923廿9924廿9925廿9926廿9927廿9928廿9929廿9822廿9823廿9824卅0580卅9930卅9931丕0012亘8017丞0015鬲7601孬8006噩0893丨0019禺4417丿0033匕0552夭1130爻3641卮1573氐3045胤5255馗7447毓3022睾4203鼗7851丶0027亟0069鼐7845乜0045乩8012亓8016芈9090孛1319啬0835嘏0858仄0090厍0623厝0625厥0628厮0631靥7243赝6372匚0557叵0672匦0567匮0566匾0573赜6358卦0597刂0596刈0435刎0437刭0462刳0453刿8109剀0481剌0469剞8104剡0470剜0468蒯5566剽1969剽0484劂8105劓0496冂0372罔4987仉8022仂8021仡0106仫0261仞0105伛0279仳0113伢0161佤7908仵0114伥0210伧0263伉0121伫8028佞0156佧3906攸2394佚0153佝0166佟0157佗0150伽8026佶0165佴8034侑0176侃0170侏0175佾0168佻0167侪0322佼8032侬0309侔0177俦0321俨0332俪0330俅8045俚0200俣8049俜8048俑0197俟0203俸0218倩0241偌8067俳0216倬0213倏0225倮0139倭0244俾0220倜0232倌0212倥0238倨0240偾0292偃0249偕0253偈0245偎0246偬8064偻0283傥0331傧0319傩8080傺8069僖0296儆0311僭0301僬8072僦0291僮0302儇0318儋0317仝0104佘0152佥0286俎0194龠7900汆8660籴4756兮0363巽1575黉7808馘7446冁0912夔5688勹0540匍0548訇6059匐0550凫7683夙1121兕0349亠0071兖0350亳0082衮5981袤5924亵5978脔5254裒5938禀4390嬴1299蠃5856羸5035冫0391冱0395冽0399冼0405冖0382冢0386冥0388讦6063讧6069讪6065讴6209讵6093讷6077诂6089诃6084诋6090诏6096诎6099诒6095诓6119诔6120诖6118诘6113诙6117诜6123诟6110诠6112诤6154诨6294诨9294诩6103诮6132诰6138诳6128诹6155诼6157诿6152谀6161谂6159谄6149谇6144谌6186谏6169谑9195谒6181谔6166谕6170谖6178谙6173谛6167谘6171谝6163谟6206谠6249谡6204谥6198谧6194谪6207谫6237谮6220谯6222谲6216谳6250谵6228谶6244卩0599卺0610阝7080阡7082阱7088阪7090阽9532阼7092陂7095陉7102陔7101陟7106陧7129陬7112陲7114陴7116隈7128隍7124隗7136隰7147邗9386邗6714邛6713邝6782邙6715邬6762邡6720邴6728邳6729邶6731邺6777邸6732邰6733郏6751郅6736邾6739郐6778郄6742郇6737郓9398郦6786郢6747郜6750郗6741郛6744郫9395郯6756郾9401鄄6761鄢6768鄞6769鄣9410鄱6776鄯6781鄹6780酃6784酆6785刍5368奂1147劢0535劬0507劭0508劾0511哿0776勐0515勖0521勰9623勰0533叟0652燮3610矍4236廴1692凵0422凼0053鬯7598厶0635弁1701畚3962巯8360坌0979垩1019垡1012塾1060壅1085壑1089圩0962圬0963圪8198圳1101圹1094圮0965圯8197圻0967坂0978坩0984垅8263坫0989垆1097坼0986坻8201坨1001坭0983坳0991垭7916垤8209垌8211垲1052埏1007垧1010垓0993垠0995埕8224埘1054埚8241埙1053埒1005垸8219埴1021埸1023埤1020埝1036堋8229堍8239埽8227埭1011堀8232堞1026堙1025塄1080堠1028塥8247塬8242墁1063墉1066墀1062馨7451鼙7853懿2034艽5336艿5350芊5340芨5353芄5339芎5343芑5344芗5577芙5346芫5357芸5366芾5372芰5362苣5385芘9167芷5365芮5360苋5454苌5500苁9190芩5355芡5349芪5356芟5348苄5380苎5389芤5351苡5386茉5406苤7154茏5693茇5404苜5382苴5447苒5375苘7305茌0421苻5394苓5376茑5596茆5374茔1041茕3560苕5378茜5409荑5434荛5609荜5598茈5402莒5392茼7905茴5418茱5416莛5438荞5606茯5415荏5432荇5429荃5425荟5634荟5436荀5424茗5407荠5654茭5414荦3684荥3322荨7915茛1706荩5660荪5549荸5428莳5535莴5504莠5452莪5458莓5448莜5371莅5444荼5442莩5457荽5443莸5607荻5441莘5450莞5451莨5456莺7727莼5573菁5464萁5487菘5473堇5477萘6055萋5491菽5486菖5471萜5489萸5505萑5495菔5472菟5460萏5564萃5488菸5510菹5484菪0429菅7726菀5463萦4896菰5479菡5496葑5531葚5513葳5524蒇5621葺5528蒉5614葸5527萼5501葆5508葩5518蒌5589蒎6397萱5503葭5521蓁5550蓍5558蓐5562蓦7513蒽1419蓓5563蓊5555蒿5548蒺5546蓠9201蒡5538蒹5545蒴7801蒗4538蓥9496蓣5626蔌5565甍3918蓰5572蔹5692蔟5590蔺5677蕖5608蔻5575蓿5581蓼5578蕙5610蕈5622蕨5615蕤5624蕞5612蕺5601瞢4240蕃5603蕲5682蕻5584薤5648薨5645薇5633薏5650薮5674薜5643薅5632薹5653薰5651藓5691藁5664藜5668藿5681蘧5698蘅5683蘩5694蘖5649蘼5701廾1699弈1704夼8268奁1160奕1150奚1153奘1155匏0549尢1428尬1435尴1434扪2204抟2306拊2140拚2155拗2152拮2159拮5159拶8429挹2184捋2192捃8432揶4518捱5930捺2205掎2224掴2310捭2206掬2239掊2221捩2203掮8438掼2335揸8439揠2257揿8471揄2246揎8445摒2311揆2247掾2268摅2373搠2283搌8457搦2286搡8459摞5285撄2375摭2303撖2888摺2309撷2355撙2323擀2098擐8474擗2352擢2359攉2336弋1707忒1805甙8384弑1710叱0667叽0875叩0661叨0660叻0930吒0688吆0697呋0718呒8172呖8182呃0713吡0070呗8142呙8139咂0715咔3931呷0727呱0722呤5129咚8131咛0905咄0732呦0717哂0757哒8174咧0744哓0879哔0874哕0902咻8136咿0764哙0898哜8177咪0743咤0741哝0901唛0860唠8167哽0775唔0767唢7624唏0785唑8143唧0825唪8146啧0862喏0816啉5123啭0921啁0791啕0751啐8148唼8147啖0797啶0570唳0789啜0799喋0818嗒0852喃0809喹0832喈0813喁0806喟0846啾0831喑0819啻0804嗟0842喽0853喾8185喔0845喙2877嗪0840嗷0869嗉0851嗑0836嗫0922嗔0838嗥0881嗳0897嗤0844辔6576嘈0856嘌8166嘤0919嗾0871嘧5878嘹0882嘬0872噍0887噢0889噙8168噜8183噌0886嚆8178噤0891噱0904噫0895噻0865嚅0906囗0931囝8188囡8189囵0950囫0939囹0941囿0943圄0945圊8191圉0947圜0958帏1605帙1589帔1592帑1583帱1621帻1614帼1613帷1602幄1606幔1611幛1625幞8363幡1616岌1476屺1474岍8325岐1477岖1536岈1483岘1501岙8324岑1478岚1526岜8326岵1487岢1482岽1506岬8328岫1485岱1486岣1490峁1475岷1488峄1542峒1491峤1540峋1493峥1513崂1555崃1503崧1516崦1517崮8339崤1541崞8338崆1519崛1512嵘1539崾1547崴8343崽8342嵬1531嵛1549嵯1532嵝1530嵫1521嵋1520嵊1522嵩1529嶂1534嶙1543豳6279嶷1544巅1553彳1761彷1762彷1790徂1768徇1770徉1772後1775徕1784徙1781徜1782徨1787徭1791徵1794徼1797衢5900彡1747犴3691犷3755狃3694狁3696狎3697狍6594狨8799狯3748狩3704狲3735狴3705狷3712猁3714猃8811狺3711狻3710猗3716猡3762猊3722猞3721猝3720猕8813猢3724猥3725猬5798猱3733獐3742獍3741獗3744獠3750獬3749獯3753獾8814舛5292夥1127飧7385夤1126夂1111饧7424饨7386饩7426饪7387饫7388饬7389饬7384饴7392饷7401饽7416馀7411馄7412馊9600馍7418馑7431馔7433庀1640庑1682庋1644庖1647庥1652庠1651庹1641庵1658庾1662庳1657赓6342廒8373廑1668廛1679廨1685廪1686膺5235忉1802忖1806忏2039怃2007忮1818忡1814忤1822忾1958怅1898怆1955忪8388忭1817忸1821怙1833怵1847怦1839怛1834怏1828怍1826怩1842怫1844怿2022怡1837恸1975恹2044恻1933恺1956恂1852恪1870恽1926悖1883悚1884悭1984悝1887悃1875悒1881悌1879悛1886惬1948悻1901悱1894惝1918惘1913惆1907惚1915悴1897愠1905愠1950愦2025愕1945惴1928愀1934愎1941愫1953慊1965慵1986憬2005憔1997憧2002懔2023懵2035忝1812隳7149闩7025闫7027闱7057闳7031闵7036闼7077闾7047阃7045阄7596阆7046阈7054阊7049阋7594阌7064阍7053阏7052阒7055阕7060阖7066阗7063阙7067阚7074爿3645戕2056汔3072汜3066汊3070沣3488沅3104沐3092沔3094沌3090汨3075汩3102汴3079汶3080沆3100沩3415泐3147泔3121沭3145泷3478泸3472泱3142泗3128泠3132泖3148泺3458泫3138泮3140沱3108泓3126泯3139泾3193洹3180洧3161洌3153浈3170洄3150洙3178洎3154洫3164浍3420洮3165洵3169洚3179浒3338浔3410洳3168涑3208浯3248涞3200涠3246涓3197涔3198浜3203浠3054浼8680浣3183渚3252淇3217淅3215淞3247渎3460涿3214淠8685渑3427淦3227淝3224淙3222渖3476渌8692涮7795渫8699湮3281湎3274湫3280溲3309湟3207溆3375湓3288湔3289渲8694渥3259湄3270滟3495溱3272溱3308溘3328滠3490漭3357滢8714溥3302溧3303溽3314溷3311溴8700滏8702溏8697滂3316溟3298潢3385潆3470潇3469漤3465漕3378滹3367漯3374漶3376潋3481潴3393漪3354漉3369漩3373澉8709澍3412澌3402潸3394潼3392潺3395濑3471濉3285澧3430澹3422澶3436濂3425濡3446濮3450濞3456濠3445濯3451瀚3466瀣3474瀛3467瀹3485瀵8717灏3493灞3496宀1336宄1339宕1349宓1348宥1359宸1368甯1380甯3942骞7505搴2291寤1393寮1402褰5973寰1403蹇6456謇6190辶6595迓6603迕6605迥6608迮9374迤6607迩6705迦6609迳6635迨6610逅6626逄6614逋6628逦6710逑6633逍6630逖6636逡6645逵6652逶6653逭6648逯6629遄6660遑6668遒6669遐6667遨6683遘6673遢6681遛6675暹2554遴6689遽6698邂6702邈6707邃6706邋9380彐1739彗1741彖1740彘1742尻1440咫0746屐1453孱1329屣1460屦1464羼5037弩1722弭1725艴5332弼1732鬻7605屮1469妁1171妃1173妍1177妩8301妪1277妣1183妗1180姊1192妫1289妞1310妤1184姒1197妲1199妯1187姗1194妾1190娅1246娆1290姝1204娈1309姣1207姘8280姹1234娌1222娉1219娲1257娴1288娴8300娑1223娣1229娓1232婀1128婊1239婕1240娼1233婢1242婵1292媪1264媛1254婷1250婺1251媾1266嫫1287媲1274嫒8302嫔1300媸1263嫠1278嫣1280嫱1297嫖1276嫦1281嫘1284嫜1286嬉1291嬗1296嬖1295嬲1303嬷1301孀1307尕1427孚1318孥1325孳1330孓1315驵9615驷7475驸7470驺7507驿7531驽7466骀7469骁7522骅7520骈7478骊7537骐7496骓7489骖7515骛7497骜7514骝7511骟7509骠7516骢7500骥7535骧7534骧7536纟4761纡4768纣4765纥4769纨4770纩4962纭4789纰9055纾4782绀4802绁9057绂4811绉4900绋4803绌4806绐4805绔4818绛4829绠4837绡4843绨4835绫4866绮4860绯4869绲9064绶4849绺4859绻4870绾4852缁4867缂9065缃4889缇4895缈4893缋4936缌4880缏4794缑9071缒4899缗4891缙4897缜4903缛4909缛4904缟4908缡4926缢4898缣4906缤4952缥4918缦4915缧4913缪4924缫4923缬4956缭4933缯4938缰4943缱4953缳4944缵4957幺1633畿3983巛1556甾3951邕6716玑3875玮3837玢3776玟3774珏3778珂3784珑3891玷3783玳3782珀3789珉3787珈3786珥3799珙3797顼7320琊3815珩3801珧3804珞3794玺3886珲8829琏8834琪3825瑛3841琦3823琥3822琨3824琰8827琮3827琬3834琛3819琚3818瑁3847瑜3842瑗3850瑕3838瑙3839瑷8842瑭8835瑾3866璜3874璎3892璀3862璇3872璋3864璞3877璨3881璩8840璐3873璧3880瓒3895韪7289韫7291韬7290杌2620杓2626杞2630杈2617枥2931枇2657杪2634杳2641枘2660枧8565杵2643枨2763枞2878枭2743枋2658杷2618杼2645柰2690栉2802柘2678栊2934柩2943枰2695栌5260柙2679枵2664柚2680枳2663柝2682栀2738枸2667柢2685栎2929柁2670柽2906栲2723栳2724桠8571桡2889桎2716桢2823桄2725梃2732栝8552桕2721桦2901桁2709桧2910桀2708栾2940桉0043栩2700梵2753梏2736桴2727桷2730梓2737桫2726棂2933楮2816棼2781椟2927椠2858棹2777棰2774椁2779楗2803棣2769椐2791椹2795楠2809楂8576楝2808榄2941楫2813榘2829楸2825椴1110槌2846榇2932榈2925槎2848榉8603楦2775楣2812楹2819榛2830榧2833榻2840榫2835榭2836槔2863榱2838槁2842槊2844槟2919榕2827槠2822槿2865樯2915樗2880橥8601槲2086樾2887檠2913橐2891橛2893樵2884檎8589橹2924樽2886樨2898橘2904橼2928檑8594檐2908檩2882檗2930猷3731獒3743殁2985殂2987殇2999殄2989殒2998殓3003殍2993殚3000殛2997殡3004殪3002轫6514轭6515轱6517轲9363轳6578轵6520轶6522轸6518轷6521轹6577轺6523轼6524轾6531辁6530辂6526辄6532辇6542辋6545辍6541辎6539辏6550辘6564辚9368戋2055戛2059戟2060戢2061戡2063戥2062戤2072戬2065臧5258瓯3917瓴3909瓿3916甏8853甑3920甓3921攴2391旰2486昊8504昙2560杲2640昃2493昕2500昀8502炅8732曷2578昝2501昴2510昱2509昶2512昵2511耆5075晟8508晔8518晁2513晏2518晖2547晡2523晗2498晷2534暄2537暌8514暧8519暝2544暾2557曛2564曜2565曦2569曩2571贲6321贳6322贶6315贻6318贽6360赀6309赅6326赆6367赈6331赉6336赇6434赇6334赍6340赙6355觇6019觊6025觋6021觌6032觎6022觏6026觐6027觑6028牮8781牝3663牦3036牯3672牿3678犄8787犋3674犍3682犒3683挈2173挲2199掰8428搿8466擘2353耄5073毳3035毵8633毹3039氅3037氇5272氆7239氍3042氕8646氘8647氙7912氚8648氡0598氩8645氤3052氪4121氲3053敕2406敫8490牍3658牒3655牖3657爰3633虢5716刖0440肜9109肓5134肼3661肱5147肫5145肴5149肷5222胧2604胨0616胪5251胛9113胂5155胄5153胙5161胍5157朐2593胝5164胫5185胱5180胴0634胭5168脍5239胼5173朕2596脒5167豚6270脞9120脬5193脘5184脲6295腈5187腌9131腓5203腴5208腱5213腠5216腩5220腭7890塍1039媵1262膈5224膂5219膑9141滕3326臌1746朦2603臊5246膻5238欤2968欷2950欹2951歃2955歆2956歙2965飑9587飒7366飓7367飕7372飙7374殳3007彀1733毂6560觳6049斐2431齑7874斓2433於2456旆2465旄2463旃2462旌2468旎2459旒2471旖2470炀3568炜3555炖3625炝7294炷3522炫3514炱3520烨8763焓1799焖3626焱8746煜3558煨3566煅3548煊3551熳8759熵7772熨3580熠3584燠3603燔3600燧3606燹3611爝3622爨3627焘3614煦3563熹3588戾2074戽2077扃2079扈2083扉2084祀4358祆4360祉4363祛4374祛5925祜4375祓4369祚4373祢4410祗4372祠4379祯4394祧4383祺4388禅4407禊4397禚8981禧4406禳4412忑1810忐1809怼2029恝1862恚1861恧1867恁1851恙1860恣1864悫1952愆1936愍1940慝1973憩2004憝2000懋2021懑2030戆2045聿5124沓3101淼8693矶4335矸1632砀4307砉4264砗4287砘1116砑4267斫4273砭4269砜4277砝8935砝6394砹0032砺4350砻4352砟4270砼4279砥4272砬4246砣8932砩1468硎4283硭8947硖4286硗4338砦4274硐8943硇6257硪8948碛4332碓4302碚8951碇4299碡4304碣4309碲0556磔4325磙4324磉4327磬4334磲4336礅4321磴4347礞8968礴4353龛7896黹7832黻7833黼7834盱4173眄4165盹8901眇4166眈4167眚8904眢8905眙4182眭4242眦4180眵4184眸4188睐4202睑3636睇4195睚4199睨4194睢4205睥4211睿4213瞍4218睽8915瞀4214瞌4209瞑4220瞟8918瞠4222瞰4230瞽4233町3957畀3952畎3955畋3953畈8858畈9426畛3963畲3974畹3979疃8859罘4989罡4993罟4992詈6091罨5001罴5013罱4493罹5008羁5015罾9088盍4137盥4150蠲5873钆1576钇7918钋9437钊6856钌5100钍7907钏6861钐9438钔5330钗6865钕6381钚0359钛7835钜6880钤6870钫9443钪3993钭9445钬2982钯6867钰6877钲6891钴6895钶4100钷7182钹6876钺6885钼9453钽7843钿6879铄7007铈7775铉6881铊7809铋6940铌6281铍9448铎6995铐9456铑4553铒1436铕7921铗6911铙6984铛6997铟7920铠6963铢6899铤6910铥0576铧6985铨6898铪1760铩9494铫6903铮6927铯7597铳6893铵6941铷7560铹6909铼4414铽7870铿6972锂9465锆1691锇1154锉6908锊9466锎3987锏9505锒9467锓6913锔3767锕0026锖9478锘6959锛6935锝0539锞9481锟6924锢6933锫6844锬9477锱6926锲6951锴6946锶7600锷6948锸6950锾6953锿0028镂6979锵6973镄1561镅5296镉9493镌6990镎6014镏9490镒6965镓3006镔7001镖6977镗6974镘6976镛6978镞6968镝6970镡9509镢9510镤7235镥5266镦9503镧4420镨9506镩0381镪6987镫6989镬7000镯6992镱7919镳7009锺6945矧4250矬8926雉7164秕4431秭4444秣4438秫4443稆7251嵇1518稂4450稞4459稔4457稹4466稷4469穑4484黏7811馥7450穰4492皈4107皎4109皓4110皙2531皙4112皤4115瓞3901瓠3902甬3941鸠7682鸢7687鸨7691鸩7690鸪7698鸬7760鸲7702鸱7689鸶7748鸷7747鸺7707鸾7762鹁7712鹂7765鹄7711鹆7714鹈7708鹉7713鹌7715鹑7718鹕7724鹗7725鹚7732鹞7740鹣7738鹦7761鹧7744鹩7754鹪7753鹫7750鹫7755鹬7756鹭7752鹳7764疒3994疔3995疖4081疠4087疝3999疬4078疣4001疳4007疴4008疸4010痄4005疱6711疰4020痃3996痂4018痖4042痍4021痣4029痨4072痤8871痫4073痧4025瘃8873痱4032痼4037痿4039瘐4049瘀4040瘅8883瘌8877瘗4053瘥4059瘘4068瘕4051瘼4069瘢4057瘠4055瘭8880瘰4064瘿4086瘵4067癃4071瘾4090瘳4065癞4088癜4080癖4075癫4094癯4091翊5042竦4548穸4497穹4498窀4503窆4506窈4507窕4511窦4535窠4517窬4521窭4526窳4524衩5908衲5906衽5910衿5912袂5927袢5983裆5991裢9260裎5935裣5990裱5950褚5969裼5954裨5947裾5957裰5949褡5968褙5967褓5965褛5997褊5959褴5996褫5972褫4404褶5977襁5982襦5993疋3988胥5171皲4125皴4123矜4244耒5085耔5086耖0390耜5091耠2605耢5092耦5096耧5098耩5095耨5097耋5077聃5106聆5107聒5109聩5118聱9107覃6009顸7310颀7322颃7314颉7327颌9577颍3379颍7336颏7331颔7318颚7329颛7348颟7354颡7350颢7355颦7360虍5705虔5709虬5876虮5843虿5860虺5726虻5724蚨5738蚍5728蚋5731蚬9223蚝5823蚧5735蚣5733蚪5737蚓5727蚩5736蚶5743蛄5745蛎5869蚰5740蚱5741蚯5739蛉5749蛏5855蛩5757蛱5758蛲7455蛭5759蛳5825蛐5792蜓5767蛞4157蛴9242蛟5754蛘5761蛑5750蜃5763蜇5764蛸5768蜈5765蜊5774蜍5773蜉5772蜣5780蜻5808蜞5786蜥5782蜮5790蜚5777蜾5811蝈5841蜴5785蜱7023蜩5781蜷5806蜿5800螂5788蜢5789蝻5813蝠5799蝌5809蝮5803蝓9227蝣5812蝼5829蝤9230蝙5796蝥5801螓9231螯5837螨5819蟒5845蟆5840螅7911螭5835螗9236螃5824螫5826蟥2434螬5834螵9237螳5838蟋5842螽5830蟑7924蟀5839蟊5833蟛5846蟪5844蟠5847蟮5807蠖5863蠓5817蟾5853蠛5864蠡5867蠹5871缶4970罂4981罄4977罅4978舐5288竺4555竽4556笈4559笃4648笄4558笕4600笊4560笫4573笏4561筇4582笪4572笙4563笮4575笱4578笠4567笥4568笤4566笳4579笾4710笞4565筘9010筚4656筅4580筵4605筌4586筝4620筠4596筮4602筲4603筱4607箐4621箦4660箧4640箸4632箬4527箬4627箝4617箨4703箪4673箜4625箫4682箴4631篑4676篁4635篌4667篝4645篚4644篥9018篦4653篪4654簌4665篾4668簏4666簖1113簋4663簟4672簪4681簦4678簸4684籁4704籀4699臾5274舁5275舂5277舄5278臬5262衄5880舡5299舢9152舣5320舨9153舫5302舸5308舻5325舳5310舴5311艄5314艋5313艟5321艨5322衾5911袅5934袈5914裘5941裟5945襞9268羝5025羟7278羧5033羯5031羰7856羲5032籼4729敉2401粑4757粝4755粜4759粞9035粢4726粲4732粼4736粽9040糁4746糇4742糌9048糍0371糈4738糅9041糗4744艮5327暨2555羿5056翎5044翕5047翥5053翡5051翦5054翩5055翮5058翳5061絷4916綦4847綮4851繇4925纛4966麸9690麴7800赳6383趄6388趱9328赧6377赭6379豇6263豉6262酊6789酐1638酎6793酏6559酤6800酢6797酡6801酰7913酩6802酯7927酽9433酾9432酲6805酴6809酹6810醌4128醅6813醐6820醍6819醑9428醢6826醣7864醪6828醭0085醮6831醯6832醵6835醴6833醺6836豕6269鹾7771趸6485跫6417蹙6464蹩9345趵6399趼3644趺6402跄6461跖6412跗6416跚6413跞6491跎6408跏6409跛6414跬6423跷6475跸6462跣6420跹6494跻6487跤9332踉6428跽6427踔6433踝6435踟6442踬6492踮6443踣6438踯6490蹀6454踹6447踵6446踽6449踱6453蹉6458蹁6450蹂6451蹑6495蹒6466蹊6459蹊1793蹰6480蹶6474蹼6349蹼9349蹯6471蹴6473躅6483躏6497躔6493躐6489躞9351豸6282貂6285貊6289貅6287貔6293斛2437觖6039觞6050觚6040觜9278觥6044觫6046觯6052訾6088謦6205靓7232雩7184雩7084雳7225雯7186霆7200霁7221霈7198霏7204霎7203霪7214霭7224霰7213霾7877龀7223龃7880龆7882龈7883龉7886龊7887龌7891黾7836鼋7837鼍7842隹7155隼7157隽7165雎7168雒7170瞿4234雠6241銮7019錾6983鍪9482鏊9495鎏9497鑫9515鱿7626鲂7629鲅9641鲇7630鲈7678稣4479鲋7631鲎7670鲐7632鲑7634鲒9643鲔7635鲕9642鲚9662鲛7640鲞7638鲟7669鲠7643鲡7657鲢9654鲣3028鲥7661鲦9655鲧7641鲨7644鲩7652鲫7651鲭7645鲮7677鲰9646鲱9656鲲7649鲳7647鲴9657鲵7646鲶7664鲷9648鲻9647鲽7654鳄9653鳅7655鳆9652鳇9650鳊7653鳌7663鳍7662鳎9660鳏7659鳓5016鳔7674鳕7914鳗7665鳘7676鳙9663鳜7675鳝7668鳟7923鳢9661靼9557鞅7248鞑7275鞯7277鞫7265鞣7558鞲7271鞴7272骱7543骰7544骷7545鹘7737骶7541骼7547髁9629髀7549髅7551髋7556髑7553魅7613魃7610魇7623魉7619魈7617魍7618魑7620飨7440餍7441餮7421饕7439饔7438髟7561髡7562髦7565髯7570髫7567髻7573髭7568髹7574鬈7576鬓7589鬟7587鬣7588麽7803麾7804縻4919麂7774麇8448麇7778麈7779麋7780麋2209麒7784鏖6971麝7790麟7792黛7818黜7819黝7821黠7822黟9694黩7830黧7824黥7823黯7826鼢7858鼬7860鼯7861鼹7862鼷7863鼽7866鼾7867";
        static MorseConvertChinese()
        {
            char key = '\0';
            char[] str = new char[4];
            int i = -1;
            foreach(var one in yuan)
            {
                if (i == -1)
                {
                    key = one;
                }
                else
                {
                    str[i] = one;
                }
                i++;
                if(i>=str.Length )
                {
                    morseCode[key] = new string(str);
                    i = -1;
                }
            }
        }
        public static string word2morse(string str)
        {
            StringBuilder morse = new StringBuilder();
            str = str.ToUpper().ToDBC();
            foreach (char s in str)
            {
                if (morseCode.ContainsKey(s))
                {
                    morse.Append(morseCode[s]);
                }
            }
            return MorseConvert.word2morse(morse.ToString());
        }

        public static string morse2word(string morse)
        {
            string word = MorseConvert.morse2word(morse);
            char[] charset = new char[4];
            int seti = 0;
            StringBuilder sb = new StringBuilder();
            foreach (char str in word)
            {
                charset[seti] = str;
                seti++;
                if(seti >3)
                {
                    foreach (var item in morseCode)
                    {
                        if (item.Value.ToString() == new string(charset))
                        {
                            sb.Append(item.Key.ToString());
                            break;
                        }
                    }
                    seti = 0;
                }
            }
            return sb.ToString().ToSBC();
        }
    }
}
