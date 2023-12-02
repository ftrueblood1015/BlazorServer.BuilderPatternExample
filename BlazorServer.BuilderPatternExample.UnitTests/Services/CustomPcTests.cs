using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Repositories.Cpus;
using BlazorServer.BuilderPatternExample.Repositories.CustomPcs;
using BlazorServer.BuilderPatternExample.Repositories.Gpus;
using BlazorServer.BuilderPatternExample.Repositories.HardDrives;
using BlazorServer.BuilderPatternExample.Repositories.Rams;
using BlazorServer.BuilderPatternExample.Services.Cpus;
using BlazorServer.BuilderPatternExample.Services.CustomPcs;
using BlazorServer.BuilderPatternExample.Services.Gpus;
using BlazorServer.BuilderPatternExample.Services.HardDrives;
using BlazorServer.BuilderPatternExample.Services.Rams;
using BlazorServer.BuilderPatternExample.UnitTests.MoqBases;

namespace BlazorServer.BuilderPatternExample.UnitTests.Services
{
    internal class CustomPcTests
    {
        private readonly CustomPcService CustomPcService;
        private readonly CpuService CpuService;
        private readonly GpuService GpuService;
        private readonly RamService RamService;
        private readonly HardDriveService HardDriveService;

        private readonly PcLevel Base;
        private readonly PcLevel Mid;
        private readonly PcLevel Top;

        public CustomPcTests()
        {
            var CustomPcRepo = MockRepos.MockRepo<ICustomPcRepository, CustomPc>(new List<CustomPc>()
                {
                    new CustomPc { Id = 1, HardDriveId = 1, CpuId = 1, GpuId = 1, RamId = 1, PcLevelId = 1, Name = "Name", 
                        CustomerName = "Name", Description = "Desccription", Slug = "Slug", TotalCost = 550 },
                }    
            );

            var CpuRepo = MockRepos.MockRepo<ICpuRepository, Cpu>(new List<Cpu>()
                {
                    new Cpu { Id = 1, BaseSpeed = "1.5gHz", Cores = 4, Cost = 100, Description = "Intel i5", Name ="Intel i5", Slug = "BASE" },
                    new Cpu { Id = 2, BaseSpeed = "2.2gHz", Cores = 10, Cost = 250, Description = "Intel i7", Name ="Intel i7", Slug = "MID" },
                    new Cpu { Id = 3, BaseSpeed = "3gHz", Cores = 20, Cost = 500, Description = "Intel i9", Name ="Intel i9", Slug = "TOP" }
                }
            );

            var GpuRepo = MockRepos.MockRepo<IGpuRepository, Gpu>(new List<Gpu>()
                {
                    new Gpu { Id = 1, Cost = 300, Description = "NVIDIA GeForce RTX 2070", Name = "NVIDIA GeForce RTX 2070", Slug = "BASE" },
                    new Gpu { Id = 2, Cost = 500, Description = "NVIDIA GeForce RTX 3070", Name = "NVIDIA GeForce RTX 3070", Slug = "MID" },
                    new Gpu { Id = 3, Cost = 800, Description = "NVIDIA GeForce RTX 4070", Name = "NVIDIA GeForce RTX 4070", Slug = "TOP" }
                }
            );

            var RamRepo = MockRepos.MockRepo<IRamRepository, Ram>(new List<Ram>()
                {
                    new Ram { Id = 1, Cost = 50, Description = "8GB DDR5", Name = "8GB DDR5", RamAmount = 8, Type = "DDR5", Slug = "BASE"},
                    new Ram { Id = 2, Cost = 100, Description = "16GB DDR5", Name = "16GB DDR5", RamAmount = 16, Type = "DDR5", Slug = "MID"},
                    new Ram { Id = 3, Cost = 175, Description = "32GB DDR5", Name = "32GB DDR5", RamAmount = 32, Type = "DDR5", Slug = "TOP"}
                }
            );

            var HarDriveRepo = MockRepos.MockRepo<IHardDriveRepository, HardDrive>(new List<HardDrive>()
                {
                    new HardDrive { Id = 1, Cost = 50, Description = "256GB SSD", Name = "256GB SSD", Size = 256, Type = "SSD", Slug = "BASE"},
                    new HardDrive { Id = 2, Cost = 100, Description = "512GB SSD", Name = "512GB SSD", Size = 512, Type = "SSD", Slug = "MID"},
                    new HardDrive { Id = 3, Cost = 200, Description = "1024GB SSD", Name = "1024GB SSD", Size = 1024, Type = "SSD", Slug = "TOP"}
                }
            );

            Base = new PcLevel { Id = 1, Description = "Base Model", Name = "Base Model", Slug = "BASE" };
            Mid = new PcLevel { Id = 2, Description = "Mid Model", Name = "Mid Model", Slug = "MID" };
            Top = new PcLevel { Id = 3, Description = "Top Model", Name = "Top Model", Slug = "TOP" };

            CpuService = new CpuService(CpuRepo.Object);
            GpuService = new GpuService(GpuRepo.Object);
            RamService = new RamService(RamRepo.Object);
            HardDriveService = new HardDriveService(HarDriveRepo.Object);

            CustomPcService = new CustomPcService(CustomPcRepo.Object, CpuService, GpuService, RamService, HardDriveService);
        }

        [Test]
        public void CanCreateBasePc_CorrectCost()
        {
            // Arrange
            CustomPc BasePc = new CustomPc { CustomerName = "BasePc", PcLevelId = 1, PcLevel = Base };

            // Act
            var result = CustomPcService.Add(BasePc);

            // Assert
            result.TotalCost.ShouldBe(500);
        }

        [Test]
        public void CanCreateBasePc_CorrectCpu()
        {
            // Arrange
            CustomPc BasePc = new CustomPc { CustomerName = "BasePc", PcLevelId = 1, PcLevel = Base };

            // Act
            var result = CustomPcService.Add(BasePc);
            
            // Assert
            result.CpuId.ShouldBe(1);
        }

        [Test]
        public void CanCreateBasePc_CorrectGpu()
        {
            // Arrange
            CustomPc BasePc = new CustomPc { CustomerName = "BasePc", PcLevelId = 1, PcLevel = Base };

            // Act
            var result = CustomPcService.Add(BasePc);

            // Assert
            result.GpuId.ShouldBe(1);
        }

        [Test]
        public void CanCreateBasePc_CorrectRam()
        {
            // Arrange
            CustomPc BasePc = new CustomPc { CustomerName = "BasePc", PcLevelId = 1, PcLevel = Base };

            // Act
            var result = CustomPcService.Add(BasePc);

            // Assert
            result.RamId.ShouldBe(1);
        }

        [Test]
        public void CanCreateBasePc_CorrectHardDrive()
        {
            // Arrange
            CustomPc BasePc = new CustomPc { CustomerName = "BasePc", PcLevelId = 1, PcLevel = Base };

            // Act
            var result = CustomPcService.Add(BasePc);

            // Assert
            result.HardDriveId.ShouldBe(1);
        }

        [Test]
        public void CanCreateMidPc_CorrectCost()
        {
            // Arrange
            CustomPc MidPc = new CustomPc { CustomerName = "MidPc", PcLevelId = 2, PcLevel = Mid };

            // Act
            var result = CustomPcService.Add(MidPc);

            // Assert
            result.TotalCost.ShouldBe(950);
        }

        [Test]
        public void CanCreateMidPc_CorrectCpu()
        {
            // Arrange
            CustomPc MidPc = new CustomPc { CustomerName = "MidPc", PcLevelId = 2, PcLevel = Mid };

            // Act
            var result = CustomPcService.Add(MidPc);

            // Assert
            result.CpuId.ShouldBe(2);
        }

        [Test]
        public void CanCreateMidPc_CorrectGpu()
        {
            // Arrange
            CustomPc MidPc = new CustomPc { CustomerName = "MidPc", PcLevelId = 2, PcLevel = Mid };

            // Act
            var result = CustomPcService.Add(MidPc);

            // Assert
            result.GpuId.ShouldBe(2);
        }

        [Test]
        public void CanCreateMidPc_CorrectRam()
        {
            // Arrange
            CustomPc MidPc = new CustomPc { CustomerName = "MidPc", PcLevelId = 2, PcLevel = Mid };

            // Act
            var result = CustomPcService.Add(MidPc);

            // Assert
            result.RamId.ShouldBe(2);
        }

        [Test]
        public void CanCreateMidPc_CorrectHardDrive()
        {
            // Arrange
            CustomPc MidPc = new CustomPc { CustomerName = "MidPc", PcLevelId = 2, PcLevel = Mid };

            // Act
            var result = CustomPcService.Add(MidPc);

            // Assert
            result.HardDriveId.ShouldBe(2);
        }

        [Test]
        public void CanCreateTopPc_CorrectCost()
        {
            // Arrange
            CustomPc TopPc = new CustomPc { CustomerName = "TopPc", PcLevelId = 3, PcLevel = Top };

            // Act
            var result = CustomPcService.Add(TopPc);

            // Assert
            result.TotalCost.ShouldBe(1675);
        }

        [Test]
        public void CanCreateTopPc_CorrectCpu()
        {
            // Arrange
            CustomPc TopPc = new CustomPc { CustomerName = "TopPc", PcLevelId = 3, PcLevel = Top };

            // Act
            var result = CustomPcService.Add(TopPc);

            // Assert
            result.CpuId.ShouldBe(3);
        }

        [Test]
        public void CanCreateTopPc_CorrectGpu()
        {
            // Arrange
            CustomPc TopPc = new CustomPc { CustomerName = "TopPc", PcLevelId = 3, PcLevel = Top };

            // Act
            var result = CustomPcService.Add(TopPc);

            // Assert
            result.GpuId.ShouldBe(3);
        }

        [Test]
        public void CanCreateTopPc_CorrectRam()
        {
            // Arrange
            CustomPc TopPc = new CustomPc { CustomerName = "TopPc", PcLevelId = 3, PcLevel = Top };

            // Act
            var result = CustomPcService.Add(TopPc);

            // Assert
            result.RamId.ShouldBe(3);
        }

        [Test]
        public void CanCreateTopPc_CorrectHardDrive()
        {
            // Arrange
            CustomPc TopPc = new CustomPc { CustomerName = "TopPc", PcLevelId = 3, PcLevel = Top };

            // Act
            var result = CustomPcService.Add(TopPc);

            // Assert
            result.HardDriveId.ShouldBe(3);
        }
    }
}
