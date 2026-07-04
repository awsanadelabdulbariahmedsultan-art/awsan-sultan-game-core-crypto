# 🎮 awsan-sultan-game-core-crypto Engine powered by NVIDIA RTX Spark & Web3

<p align="center">
  <img src="./ASGCC LOGO.png" alt="ASGCC LOGO" width="1254" height="1254"/>
</p>

An advanced, highly-scalable, cross-platform Web3 Gaming Engine designed to bridge next-generation graphical technologies with decentralized economies. This engine compiles seamlessly across **all Mobile devices, PlayStation, Xbox, and high-end PCs**.

---
> 🌐 **ENTERPRISE NOTE:** The underlying core infrastructure of this engine has been architected and upgraded into a standalone commercial B2B protocol for corporate integration: **AWSAN SULTAN OMNI-ENGINE PROTOCOL (ASOEP)**. Contracted studios and institutional evaluators can access the proprietary SDK packages and automated fee clearing layer here: [Proprietary B2B Protocol Repository]([https://github.com](https://github.com/awsanadelabdulbariahmedsultan-art/-AWSAN_SULTAN_OMNI-ENGINE_PROTOCAL_-ASOEP-))
> https://github.com/awsanadelabdulbariahmedsultan-art/-AWSAN_SULTAN_OMNI-ENGINE_PROTOCAL_-ASOEP-

---

## 📊 Comprehensive Project Status Board

| Milestone Modules | Core Files & Implemented Scripts | Current Status |
| :--- | :--- | :--- |
| **Milestone 1: Repository Infrastructure & Documentation** | `README.md` , `CONTRIBUTING.md`, & `.gitignore` Configuration | [✅ Completed] |
| **Milestone 2: Blockchain Architecture & Smart Contracts** | `blockchain-core/contracts/ASTToken.sol` (Genesis & Minting Core) | [✅ Completed] |
| | `blockchain-core/contracts/AsaOmnichainAST.sol` (LayerZero Multi-Chain Bridge & Burns) | [✅ Completed] |
| | `blockchain-core/contracts/PvPRewards.sol` (On-Chain Reward Sub-Nodes & Profiles) | [✅ Completed] |
| | `blockchain-core/security/SecurityVerification.sol` (On-Chain Real-Time Auditing) | [✅ Completed] |
| **Milestone 3: Game Engine Development & Integration** | `game-client/scripts/Web3WalletManager.cs` (Auth & Wallet Interface) | [✅ Completed] |
| | `game-client/scripts/PvPMatchManager.cs` (PvP Orchestration & UI Live Sync) | [✅ Completed] |
| | `game-client/scripts/AsaAssetManager.cs` (ASA Gallery Registry & Texture Cache Management) | [✅ Completed] |
| | `game-client/scripts/GlobalEcosystemGateway.cs` (Hybrid Network & Payment Gateway) | [✅ Completed] |
| | `game-client/scripts/LayerCombiner.cs` (Procedural Texture Blending & Skin Injection) | [✅ Completed] |
| | `game-client/scripts/AsgccTestingSuite.cs` (Performance Telemetry & Automated Stress Test) | [✅ Completed] |
| | `game-client/config/ScalabilityManager.config` (Dynamic Hardware Optimization Profile) | [✅ Completed] |
| **Milestone 4: NVIDIA Technologies & AI Integration** | `game-client/plugins/NvidiaEcosystemBridge.cs` (Unified Tech Bridge Interface) | [✅ Completed] |
| | `game-client/scripts/AsgccAiEngine.cs` (Local AI via RTX Spark & XP-Linked Dialogue) | [✅ Completed] |
| | `game-client/scripts/RtxMaterialMatcher.cs` (Path Tracing Parameters & Material Keyword Injection) | [✅ Completed] |
| | `game-client/scripts/AsaMetadataGenerator.cs` (Local 45K Asset Generation Subsystem - GTA6 Inspired) | [✅ Completed] |
| | `assets/awsan-sultan-art/metadata/1.json` (ASA Metadata Deployment Configuration) | [✅ Completed] |
| | `assets/awsan-sultan-art/procedural-generator/AsaProceduralGenerator.cs` | [✅ Completed] |

---

## ✨ Key Features & Creative Investor Highlights

*   **Hybrid Graphical Pipeline:** Dynamic hardware scaling featuring full Path Tracing and NVIDIA DLSS for PC/Consoles, alongside highly-optimized mobile shaders ensuring a stable 60 FPS across all legacy and modern smartphones.
*   **Local AI via RTX Spark (Zero Cloud Cost):** Utilizing NVIDIA ACE SDK to run intelligent, context-aware NPCs locally on player hardware equipped with RTX Spark, completely wiping out monthly cloud server operation costs to maximize investment ROI.
*   **Omnichain Fee Routing Protocol:** Dynamic cross-chain transfers via `AsaOmnichainAST.sol` incur a **1% routing fee** settled natively in \$AST. The fee is split automatically: **70%** flows to the secure **Platform Treasury Wallet** to maintain liquidity, and **30%** is permanently routed to the **Burn Address**, maintaining a strict deflationary environment.
*   **Secure Competitive Gameplay & On-Chain Rewards:** Advanced low-latency synchronization powered by NVIDIA Reflex closes the input gap between mobile, PlayStation, Xbox, and PC players during live PvP sessions. Upon match conclusion, the engine automates a secure distribution of the **150 XP baseline and 10 \$AST tokens**, updating state-trees on the blockchain via `PvPRewards.sol`.

---

## 📈 Tokenomics & Strategic Economic Flow

The ASGCC economic infrastructure model establishes a sustainable ecosystem connecting standard gaming achievements directly with on-chain assets:

```text
  [PvP Match Victory] ──> Awards 150 XP & \$AST Tokens ──> Monitored by PvPMatchManager.cs
                                                                   │
  [Ecosystem Treasury] <── 70% Fee Split (Corporate Revenue) <── [1% Cross-Chain Bridge Fee]
                                                                   │
  [Algorithmic Scarcity] <── 30% Token Burn (Supply Burn)   <── Paid Natively in \$AST
```

*   **Platform Utility Multiplier:** Any asset minting cycle or network mutation requires raw \$AST interactions. Cross-chain movements systematically decrease circulating supply via token burns, escalating token utility value as the player-base expands.


## 🛠️ Quick Start & Master Simulation Deployment

Developers and technical evaluators can initialize the comprehensive internal validation framework within the game client to monitor performance metrics:

### 1. Verification of Architecture Interfaces
Ensure all tracking interfaces are correctly linked to the execution loop by adding the primary control hooks to the active assembly scene:
```csharp
// Manual invocation sequence for technical diagnostic evaluations
await AsgccTestingSuite.Instance.ExecuteFullGameLoopSimulationAsync();
```

### 2. Launching Autonomous Performance Sweeps
To simulate high-intensity production environments and test infrastructure under strain, invoke the integrated stress-testing module inside the editor console:
* Right-click the **`AsgccTestingSuite`** component inspector view.
* Click **`Trigger Infrastructure Stress Test`** to execute 5,000 automated contract calls.
* Monitor live logs to view the average frame delivery rate and automated fee distribution splitting cycles holding under heavy loads.

---

## 📁 Detailed Project Repository Blueprint (Updated Docs)

```text
awsan-sultan-game-core-crypto/
├── assets/
│   └── awsan-sultan-art/
│       ├── metadata/
│       │   └── 1.json              # Digital asset metadata file uploaded for the ASA gallery.
│       └── procedural-generator/
│           └── AsaProceduralGenerator.cs  # Procedural generation script for asset layering from IPFS.
├── blockchain-core/              # Core blockchain technology and smart contracts directory.
│   ├── contracts/                # Contains fundamental smart contracts for the project:
│   │   ├── ASTToken.sol          # Smart contract for generating and managing the native \$AST token.
│   │   ├── AsaOmnichainAST.sol   # Smart contract dedicated to multi-chain (Omnichain) bridging and burns.
│   │   └── PvPRewards.sol        # Smart contract for distributing PvP match rewards, tracking XP and profiles.
│   └── security/                 # Contains digital security verification and auditing systems:
│       └── SecurityVerification.sol  # Smart contract for on-chain cryptographic security audits.
├── docs/                         # Documentation directory containing technical whitepapers and diagrams (Updated):
│   ├── DATA_FLOW_DIAGRAM.md      # Engineering data flow diagram for cross-platform system integration.
│   ├── DEMO_GUIDE.md             # Developer manual for quick-start deployment, hardware checks, and sweeps.
│   └── TECHNICAL_WHITEPAPER.md   # Comprehensive whitepaper detailing engine architecture and tokenomics.
├── game-client/                  # Main cross-platform game client and software engine architecture.
│   ├── config/                   # Configuration files for dynamic performance and hardware scaling:
│   │   └── ScalabilityManager.config # Configuration file for mobile compatibility and optimization tuning.
│   ├── plugins/                  # Official plugins and official software development kits (e.g., NVIDIA SDKs):
│   │   └── NvidiaEcosystemBridge.cs # Ecosystem bridge script for connecting proprietary NVIDIA technologies.
│   └── scripts/                  # Backend control scripts for handling Web3 connections and game logic:
│       ├── AsaAssetManager.cs    # Script for managing game assets and digital art gallery texture cache buffers.
│       ├── AsaMetadataGenerator.cs # Generates dynamic 45,000 asset traits locally (GTA6 Inspired).
│       ├── AsgccAiEngine.cs      # Core AI engine script for running context-aware NPCs locally with XP filters.
│       ├── AsgccTestingSuite.cs  # Automated testing and validation suite for evaluating engine performance.
│       ├── GlobalEcosystemGateway.cs # Global gateway script for handling multi-wallet and exchange integrations.
│       ├── LayerCombiner.cs      # Script for blending and combining graphical layers and injecting skin textures.
│       ├── PvPMatchManager.cs    # Controller for managing PvP matchmaking, battles, and real-time UI state sync.
│       ├── RtxMaterialMatcher.cs # Material mapping script for high-end NVIDIA RTX graphics configurations.
│       └── Web3WalletManager.cs  # Web3 wallet controller for secure player authentication and transactions.
├── .gitignore                    # Specifies intentionally untracked files that Git should ignore.
├── ASGCC LOGO.png                # Official visual brand logo displayed on the landing interface.
├── CONTRIBUTING.md               # Legal framework governing intellectual software properties in dual languages.
└── README.md                     # Main documentation file for the repository layout (the file you are reading).
```

---

## 📜 Intellectual Property & Software Ownership Notice

**IMPORTANT LEGAL NOTICE:**
All source codes, architectural designs, algorithms, UI/UX frameworks, cryptographic logic, and digital assets within this repository are the absolute and exclusive property of the innovator and lead engineer:

* **Owner Name:** ENG AWSAN ADEL ABDULBARI AHMED SULTAN
* **Nationality:** Republic of Yemen (YEMEN)
* **National ID:** 01010305468
* **Contact Email:** awsanadelsultan@outlook.com
* **International Phone:** 00967776633003 / 00967777852433

*Any unauthorized copying, modification, reverse engineering, or distribution of this proprietary work is strictly prohibited under local and international copyright and software protection laws.*




---
# 🎮 محرك awsan-sultan-game-core-crypto المدعوم بـ NVIDIA RTX Spark و Web3

<p align="center">
  <img src="./ASGCC LOGO.png" alt="ASGCC LOGO" width="1254" height="1254"/>
</p>

محرك ألعاب Web3 متطور، عالي القابلية للتوسع، وعابر للمنصات (Cross-Platform). تم تصميمه ليربط بين تقنيات الرسوميات من الجيل القادم والاقتصاد اللامركزي. يترجم هذا المحرك برمجياً ويعمل بسلاسة عبر **جميع الأجهزة المحمولة، PlayStation، Xbox، وأجهزة الكمبيوتر عالية الأداء**.

---
> 🌐 **ملاحظة مؤسسية:** تم استخلاص وترقية البنية التحتية لهذا المحرك وتحويلها إلى بروتوكول تجاري مستقل مخصص للبيع للمؤسسات والشركات (B2B) تحت اسم **AWSAN SULTAN OMNI-ENGINE PROTOCOL (ASOEP)**. يمكن للجهات والشركات المتعاقدة الاطلاع على حزمة الـ SDK وعقود توزيع وحرق الرسوم عبر الرابط التالي: [بروتوكول ASOEP التجاري الحصري على GitHub]([https://github.com](https://github.com/awsanadelabdulbariahmedsultan-art/-AWSAN_SULTAN_OMNI-ENGINE_PROTOCAL_-ASOEP-))
> https://github.com/awsanadelabdulbariahmedsultan-art/-AWSAN_SULTAN_OMNI-ENGINE_PROTOCAL_-ASOEP-

---
## 📊 لوحة تحكم شاملة لمتابعة إنجاز المشروع (Comprehensive Project Status Board)

| المحور البرمجي التقني (Milestone Modules) | الملفات والأنظمة البرمجية الفردية المنفذة (Core Files & Scripts) | الحالة الحالية (Current Status) |
| :--- | :--- | :--- |
| **المحور الأول: البنية التحتية للمستودع والتوثيق** | إعدادات ملفات `README.md` و `CONTRIBUTING.md` و `.gitignore` | [✅ تم استكماله] |
| **المحور الثاني: هندسة البلوكشين والعقود الذكية** | `blockchain-core/contracts/ASTToken.sol` (عقد التوكن والسك الأساسي) | [✅ تم استكماله] |
| | `blockchain-core/contracts/AsaOmnichainAST.sol` (الجسر ومعيار LayerZero وحرق الرسوم) | [✅ تم استكماله] |
| | `blockchain-core/contracts/PvPRewards.sol` (محرك الجوائز وملفات اللاعبين على السلسلة) | [✅ تم استكماله] |
| | `blockchain-core/security/SecurityVerification.sol` (التدقيق الأمني الفوري) | [✅ تم استكماله] |
| **المحور الثالث: تطوير محرك اللعبة والربط البرمجي** | `game-client/scripts/Web3WalletManager.cs` (ربط وإدارة المحافظ) | [✅ تم استكماله] |
| | `game-client/scripts/PvPMatchManager.cs` (متحكم معارك الـ PvP وربط الـ UI الحية) | [✅ تم استكماله] |
| | `game-client/scripts/AsaAssetManager.cs` (إدارة أصول معرض ASA وتأمين كاش الخامات) | [✅ تم استكماله] |
| | `game-client/scripts/GlobalEcosystemGateway.cs` (بوابة شبكة النظام البيئي الهجين) | [✅ تم استكماله] |
| | `game-client/scripts/LayerCombiner.cs` (دمج وتوليف طبقات الأصول والـ Skins إجرائياً) | [✅ تم استكماله] |
| | `game-client/scripts/AsgccTestingSuite.cs` (حزمة فحص واختبار أداء المحرك ومحاكاة الضغط) | [✅ تم استكماله] |
| | `game-client/config/ScalabilityManager.config` (نظام التوسيع الديناميكي للعتاد) | [✅ تم استكماله] |
| **المحور الرابع: دمج تقنيات NVIDIA والذكاء الاصطناعي** | `game-client/plugins/NvidiaEcosystemBridge.cs` (جسر تقنيات نيفيديا الموحد) | [✅ تم استكماله] |
| | `game-client/scripts/AsgccAiEngine.cs` (ذكاء اصطناعي محلي عبر RTX Spark وفتح الحوارات بالـ XP) | [✅ تم استكماله] |
| | `game-client/scripts/RtxMaterialMatcher.cs` (إعدادات تتبع المسار الكامل وحقن مفاتيح الـ RTX) | [✅ تم استكماله] |
| | `game-client/scripts/AsaMetadataGenerator.cs` (توليد ميتاداتا الـ 45 ألف لوحة محلياً - مستوحى من GTA6) | [✅ تم استكماله] |
| | `assets/awsan-sultan-art/metadata/1.json` (رفع البيانات الوصفية الرقمية لـ ASA) | [✅ تم استكماله] |
| | `assets/awsan-sultan-art/procedural-generator/AsaProceduralGenerator.cs` | [✅ تم استكماله] |

---

## ✨ الميزات الرئيسية وأبرز النقاط الجاذبة للمستثمرين

* **خط معالجة الرسوميات الهجين (Hybrid Graphical Pipeline):** توسيع ديناميكي متوافق مع العتاد، يتميز بتقنية تتبع المسار الكامل (Path Tracing) وتقنية NVIDIA DLSS لأجهزة الكمبيوتر والكونسول، إلى جانب برمجيات تظليل (Shaders) مخصصة وعالية الكفاءة للهواتف الذكية تضمن استقرار الأداء عند 60 إطاراً في الثانية على جميع الهواتف القديمة والحديثة.
* **ذكاء اصطناعي محلي عبر RTX Spark (بدون تكاليف سحابية):** استخدام حزمة أدوات تطوير البرمجيات NVIDIA ACE لتشغيل شخصيات غير لاعبة (NPCs) ذكية وتتفاعل حسب السياق محلياً على عتاد اللاعب المزود بـ RTX Spark، مما يلغي تماماً التكاليف التشغيلية الشهرية للخوادم السحابية ويعظم العائد على الاستثمار (ROI).
* **بروتوكول توجيه الرسوم عابرة السلاسل والأرباح:** عمليات التحويل الذكية داخل عقد `AsaOmnichainAST.sol` تقتطع رسوماً بنسبة **1%** تُدفع مباشرة بعملة **\$AST** عند الانتقال بين الشبكات. يتم تقسيم الرسوم تلقائياً: **70%** تحول فوراً إلى **محفظة عوائد المنصة** لضمان السيولة وتأمين الأرباح، و**30%** تُحرق نهائياً لحماية اقتصاد العملة الانكماشي وتوفير أعلى عائد استثماري لمعرض "Awsan Sultan Art (ASA)".
* **اللعب التنافسي المشترك ومكافآت السلسلة الآمنة:** مزامنة متطورة مدعومة بتقنية NVIDIA Reflex لتقليص فجوة زمن الاستجابة (Latency) بين لاعبي الهواتف المحمولة، PlayStation، Xbox، والكمبيوتر الشخصي أثناء مباريات PvP الحية، متبوعة بتوزيع آمن وتلقائي لمكافأة الـ **150 XP و 10 توكنز \$AST** وحفظها داخل مصفوفات ملفات اللاعبين على البلوكشين عبر عقد `PvPRewards.sol`.

---

## 📈 اقتصاد التوكنز ومسار التدفق الاستراتيجي (Tokenomics Flow)

يؤصل النموذج الاقتصادي للبنية التحتية لـ ASGCC نظاماً مستداماً يربط الإنجازات التقليدية للألعاب مباشرة بالأصول الرقمية على السلسلة:

```text
  [انتصار بمباراة PvP] ──> يمنح 150 XP وتوكنز \$AST ──> تتم متابعته عبر PvPMatchManager.cs
                                                                   │
  [خزينة النظام البيئي] <── حصة 70% من الرسوم (أرباح المنصة) <── [1% رسوم تحويل الجسر]
                                                                   │
  [شح التوكنز التدريجي] <── حرق 30% من الرسوم (تقليل المعروض) <── تُدفع مباشرة بالـ \$AST
```

* **مضاعف فائدة المنصة:** تتطلب أي دورة سك أصول أو تعديل للشبكة تفاعلات مباشرة لتوكن \$AST. وتعمل التحركات عابرة السلاسل على خفض المعروض المتداول بانتظام عبر آلية الحرق، مما يرفع القيمة النفعية للتوكن بالتوازي مع نمو قاعدة اللاعبين.

## 🛠️ دليل البدء السريع ومحاكاة التشغيل الرئيسي (Quick Start)

يمكن للمطورين والجهات المقيمة تقنياً تشغيل إطار الفحص الداخلي الشامل داخل عميل اللعبة لمراقبة قياسات الأداء والأمان:

### 1. التحقق من واجهات الربط والهندسة البرمجية
للتأكد من أن جميع واجهات التتبع متصلة بحلقة التنفيذ بشكل صحيح، قم بإضافة أوامر التحكم الرئيسية إلى مشهد العميل النشط:
```csharp
// استدعاء يدوي متكامل لتشغيل المحاكاة التشخيصية واختبار المنظومة الشاملة
await AsgccTestingSuite.Instance.ExecuteFullGameLoopSimulationAsync();
```

### 2. إطلاق فحص الضغط الآلي للبنية التحتية
لمحاكاة بيئات التشغيل الحية عالية الكثافة واختبار قدرة المنظومة تحت الضغط، قم بتنشيط وحدة اختبار الضغط المدمجة من واجهة المحرر:
* انقر بزر الفأرة الأيمن على واجهة المفتش (Inspector View) لمكون **`AsgccTestingSuite`**.
* اختر الأمر **`Trigger Infrastructure Stress Test`** لتنفيذ 5000 استدعاء آلي ومؤتمت للعقود الذكية.
* راقب سجلات المحرك الفورية للتأكد من استقرار معدل بث الإطارات (FPS) تحت الضغط العالي للشبكة وعمليات اقتطاع رسوم الأرباح بنجاح.

---

## 📁 المخطط التفصيلي لبنية مستودع المشروع المعماري الحقيقي (Updated Docs)

```text
awsan-sultan-game-core-crypto/
├── assets/
│   └── awsan-sultan-art/
│       ├── metadata/
│       │   └── 1.json              # ملف البيانات الوصفية الرقمية المرفوع لنظام معرض ASA
│       └── procedural-generator/
│           └── AsaProceduralGenerator.cs  # سكربت التوليد الإجرائي لطبقات الأصول الفنية من الـ IPFS
├── blockchain-core/              # المجلد الأساسي لتقنيات البلوكشين والعقود الذكية
│   ├── contracts/                # مجلد يحتوي على العقود الذكية الأساسية للمشروع:
│   │   ├── ASTToken.sol          # عقد إنشاء وتدبير توكن \$AST المميز للمشروع
│   │   ├── AsaOmnichainAST.sol   # عقد ذكي مخصص للربط ونقل التوكن عابر السلاسل وحرق الرسوم تلقائياً
│   │   └── PvPRewards.sol        # عقد توزيع مكافآت مباريات PvP وحساب الجوائز وملفات اللاعبين على السلسلة
│   └── security/                 # مجلد يحتوي على ملفات وأنظمة التحقق الأمني الرقمي على السلسلة:
│       └── SecurityVerification.sol  # عقد ذكي مخصص لعمليات التحقق والتدقيق الأمني التشفيري
├── docs/                         # مجلد التوثيق والملفات التقنية والورقة البيضاء لهندسة المشروع (محدث):
│   ├── DATA_FLOW_DIAGRAM.md      # مخطط تدفق البيانات الهندسي للمشروع والتكامل البرمجي المشترك
│   ├── DEMO_GUIDE.md             # دليل المطورين والشركات للتشغيل السريع وفحص العتاد والأداء
│   └── TECHNICAL_WHITEPAPER.md   # الورقة البيضاء التقنية الشاملة لبنية المحرك والاقتصاد الرقمي وعوائد الرسوم
├── game-client/                  # مجلد العميل الخاص بمحرك اللعبة والربط البرمجي عبر المنصات
│   ├── config/                   # مجلد يحتوي على ملفات الإعدادات وتوسيع الأداء ديناميكياً:
│   │   └── ScalabilityManager.config # ملف تكوين وضبط مرونة الأداء والتوافق مع الهواتف المحمولة والعتاد
│   ├── plugins/                  # مجلد الإضافات وحزم التطوير الرسمية (مثل حزم SDK لـ NVIDIA):
│   │   └── NvidiaEcosystemBridge.cs # سكربت الربط البرمجي البريدج الموحد لربط بيئة عمل وتقنيات نيفيديا
│   └── scripts/                  # مجلد أكواد التحكم الخلفية لإدارة منطق اللعبة والربط البرمجي لبيئة العمل:
│       ├── AsaAssetManager.cs    # سكربت إدارة أصول معرض الفن الرقمي واللعبة وتأمين كاش الخامات المستدعاة
│       ├── AsaMetadataGenerator.cs # توليد إجرائي محلي لخصائص الـ 45 ألف لوحة ومستويات الندرة (مستوحى من GTA6)
│       ├── AsgccAiEngine.cs      # سكربت محرك الذكاء الاصطناعي لتشغيل الـ NPCs محلياً وربطها بالـ XP لحقن الحوارات
│       ├── AsgccTestingSuite.cs   # حزمة برمجيات الفحص واختبار أداء وكفاءة عمل المحرك ومحاكاة الضغط والـ FPS
│       ├── GlobalEcosystemGateway.cs # بوابة النظام البيئي الهجين للربط مع المحافظ والمتاجر العالمية والـ CEX وحساب الرسوم
│       ├── LayerCombiner.cs      # سكربت دمج ومعالجة الطبقات البرمجية والرسومية وحقن الـ Textures وخصائص الـ Skin المخصص
│       ├── PvPMatchManager.cs    # متحكم تنظيم مباريات الـ PvP وتوزيع مكافأة الـ 150 XP والتوكنز حياً وتحديث الـ UI
│       ├── RtxMaterialMatcher.cs # سكربت مطابقة وإعداد خامات RTX وتفعيل الـ Keywords والـ Path Tracing والـ Shaders
│       └── Web3WalletManager.cs  # متحكم ربط وإدارة محافط الـ Web3 الرقمية للاعبين والتحقق الآمن
├── .gitignore                    # ملف تخصيص استبعاد الملفات والبيانات غير المرغوبة من التتبع والمزامنة
├── ASGCC LOGO.png                # الشعار المرئي الرسمي الخاص بالعلامة التجارية للمشروع المعروض في الواجهة
├── CONTRIBUTING.md               # وثيقة الشروط القانونية وحماية الملكية الفكرية والبرمجية الحصرية للمشروع بلغتين
└── README.md                     # ملف التوثيق الأساسي والمخطط التوضيحي للمستودع الحالي (الملف الذي تقرأه الآن)
```

---

## 📜 إشعار الملكية الفكرية وحقوق ملكية البرمجيات

**إشعار قانوني هام:**
جميع الأكواد المصدرية، والتصميمات الهندسية البرمجية، والخوارزميات، وأطر عمل واجهة وتجربة المستخدم (UI/UX)، والمنطق التشفيري، والأصول الرقمية داخل هذا المستودع هي ملكية مطلقة وحصرية للمبتكر والمهندس الرائد:

* **اسم المالك:** المهندس أوسان عادل عبدالباري أحمد سلطان (ENG AWSAN ADEL ABDULBARI AHMED SULTAN)
* **الجنسية:** الجمهورية اليمنية (YEMEN)
* **الرقم الوطني:** 01010305468
* **البريد الإلكتروني للتواصل:** awsanadelsultan@outlook.com
* **الهاتف الدولي:** 00967776633003 / 00967777852433

*يُمنع منعاً باتاً أي نسخ غير مصرح به، أو تعديل، أو هندسة عكسية، أو توزيع لهذا العمل المملوك بموجب قوانين حماية حقوق الطبع والنشر والبرمجيات المحلية والدولية.*
