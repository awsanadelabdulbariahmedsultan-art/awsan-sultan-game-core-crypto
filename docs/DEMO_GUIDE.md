# دليل التشغيل السريع واختبار أداء المحرك (Quick Start & Diagnostics Guide)

مخصص للمطورين والمستثمرين لتهيئة واختبار ربط الرسوميات والويب 3 والذكاء الاصطناعي محلياً على الأجهزة:

### 1. الإعداد الأولي داخل محرك اللعبة (Editor Environment Setup)
1. قم بسحب وإسقاط السكربت الشامل `GlobalEcosystemGateway.cs` على كائن فارغ (GameObject) في المشهد الرئيسي للعبة.
2. تأكد من إدراج المكونات `AsgccTestingSuite.cs` و `RtxMaterialMatcher.cs` في نفس كائن التحكم لتوليد التكامل التلقائي.

### 2. محاكاة دورة اللعبة كاملة بضغطة زر واحدة (One-Click Game Loop Simulation)
لاختبار ربط المحفظة، ومعارك الـ PvP واحتساب الـ 150 XP، واستدعاء الذكاء الاصطناعي المحلي وتلبيس خامات الـ RTX من الـ IPFS معاً:
* قم بتشغيل وضع اللعب في المحرك (**Play Mode**).
* ابحث عن كاميرا ومفتش الـ **`AsgccTestingSuite`**.
* انقر فوق زر **`Execute Full Game Loop Simulation`** من نافذة الـ Context Menu.
* راقب سجلات المطورين (Console Logs) للتأكد من طباعة جملة:
  `============== GLOBAL ASGCC SIMULATION COMPLETED SUCCESSFULLY [100%] ==============`

### 3. اختبار تحمل البنية التحتية للمؤسسات (Corporate Infrastructure Stress Test)
لمحاكاة ضغط شبكي هائل وقياس كفاءة تحويل عوائد الرسوم وحرق الـ 30% دون انهيار الإطارات:
* من واجهة المفتش لـ `AsgccTestingSuite`، انقر على **`Trigger Infrastructure Stress Test`**.
* يقوم المحرك بشن 5,000 استدعاء فوري ومحاكى لعقد الجسر.
* راقب استقرار معدل الإطارات الفعلي المقاس حياً عبر متغير `MeasuredAverageFps` للتأكد من ثباته عند **60 FPS**.
