﻿// <auto-generated />
using System;
using InspireUs.Congress.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InspireUs.Congress.Infrastructure.Migrations
{
    [DbContext(typeof(CongressDbContext))]
    partial class CongressDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InspireUs.Congress.Domain.Model.Legislation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BillNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CongressNth")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("IntroducedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SponserMemberId")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CongressNth");

                    b.HasIndex("SponserMemberId");

                    b.ToTable("Legislation");
                });

            modelBuilder.Entity("InspireUs.Congress.Domain.Model.Member", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ContactUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("MemberType")
                        .HasColumnType("int");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Party")
                        .HasColumnType("int");

                    b.Property<int?>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebsiteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("InspireUs.Congress.Domain.Model.UsCongress", b =>
                {
                    b.Property<string>("Nth")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("EndDate")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("StartDate")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Nth");

                    b.ToTable("UsCongress");

                    b.HasData(
                        new
                        {
                            Nth = "1st",
                            EndDate = 1790,
                            StartDate = 1789
                        },
                        new
                        {
                            Nth = "2nd",
                            EndDate = 1792,
                            StartDate = 1791
                        },
                        new
                        {
                            Nth = "3rd",
                            EndDate = 1794,
                            StartDate = 1793
                        },
                        new
                        {
                            Nth = "4th",
                            EndDate = 1796,
                            StartDate = 1795
                        },
                        new
                        {
                            Nth = "5th",
                            EndDate = 1798,
                            StartDate = 1797
                        },
                        new
                        {
                            Nth = "6th",
                            EndDate = 1800,
                            StartDate = 1799
                        },
                        new
                        {
                            Nth = "7th",
                            EndDate = 1802,
                            StartDate = 1801
                        },
                        new
                        {
                            Nth = "8th",
                            EndDate = 1804,
                            StartDate = 1803
                        },
                        new
                        {
                            Nth = "9th",
                            EndDate = 1806,
                            StartDate = 1805
                        },
                        new
                        {
                            Nth = "10th",
                            EndDate = 1808,
                            StartDate = 1807
                        },
                        new
                        {
                            Nth = "11th",
                            EndDate = 1810,
                            StartDate = 1809
                        },
                        new
                        {
                            Nth = "12th",
                            EndDate = 1812,
                            StartDate = 1811
                        },
                        new
                        {
                            Nth = "13th",
                            EndDate = 1814,
                            StartDate = 1813
                        },
                        new
                        {
                            Nth = "14th",
                            EndDate = 1816,
                            StartDate = 1815
                        },
                        new
                        {
                            Nth = "15th",
                            EndDate = 1818,
                            StartDate = 1817
                        },
                        new
                        {
                            Nth = "16th",
                            EndDate = 1820,
                            StartDate = 1819
                        },
                        new
                        {
                            Nth = "17th",
                            EndDate = 1822,
                            StartDate = 1821
                        },
                        new
                        {
                            Nth = "18th",
                            EndDate = 1824,
                            StartDate = 1823
                        },
                        new
                        {
                            Nth = "19th",
                            EndDate = 1826,
                            StartDate = 1825
                        },
                        new
                        {
                            Nth = "20th",
                            EndDate = 1828,
                            StartDate = 1827
                        },
                        new
                        {
                            Nth = "21st",
                            EndDate = 1830,
                            StartDate = 1829
                        },
                        new
                        {
                            Nth = "22nd",
                            EndDate = 1832,
                            StartDate = 1831
                        },
                        new
                        {
                            Nth = "23rd",
                            EndDate = 1834,
                            StartDate = 1833
                        },
                        new
                        {
                            Nth = "24th",
                            EndDate = 1836,
                            StartDate = 1835
                        },
                        new
                        {
                            Nth = "25th",
                            EndDate = 1838,
                            StartDate = 1837
                        },
                        new
                        {
                            Nth = "26th",
                            EndDate = 1840,
                            StartDate = 1839
                        },
                        new
                        {
                            Nth = "27th",
                            EndDate = 1842,
                            StartDate = 1841
                        },
                        new
                        {
                            Nth = "28th",
                            EndDate = 1844,
                            StartDate = 1843
                        },
                        new
                        {
                            Nth = "29th",
                            EndDate = 1846,
                            StartDate = 1845
                        },
                        new
                        {
                            Nth = "30th",
                            EndDate = 1848,
                            StartDate = 1847
                        },
                        new
                        {
                            Nth = "31st",
                            EndDate = 1850,
                            StartDate = 1849
                        },
                        new
                        {
                            Nth = "32nd",
                            EndDate = 1852,
                            StartDate = 1851
                        },
                        new
                        {
                            Nth = "33rd",
                            EndDate = 1854,
                            StartDate = 1853
                        },
                        new
                        {
                            Nth = "34th",
                            EndDate = 1856,
                            StartDate = 1855
                        },
                        new
                        {
                            Nth = "35th",
                            EndDate = 1858,
                            StartDate = 1857
                        },
                        new
                        {
                            Nth = "36th",
                            EndDate = 1860,
                            StartDate = 1859
                        },
                        new
                        {
                            Nth = "37th",
                            EndDate = 1862,
                            StartDate = 1861
                        },
                        new
                        {
                            Nth = "38th",
                            EndDate = 1864,
                            StartDate = 1863
                        },
                        new
                        {
                            Nth = "39th",
                            EndDate = 1866,
                            StartDate = 1865
                        },
                        new
                        {
                            Nth = "40th",
                            EndDate = 1868,
                            StartDate = 1867
                        },
                        new
                        {
                            Nth = "41st",
                            EndDate = 1870,
                            StartDate = 1869
                        },
                        new
                        {
                            Nth = "42nd",
                            EndDate = 1872,
                            StartDate = 1871
                        },
                        new
                        {
                            Nth = "43rd",
                            EndDate = 1874,
                            StartDate = 1873
                        },
                        new
                        {
                            Nth = "44th",
                            EndDate = 1876,
                            StartDate = 1875
                        },
                        new
                        {
                            Nth = "45th",
                            EndDate = 1878,
                            StartDate = 1877
                        },
                        new
                        {
                            Nth = "46th",
                            EndDate = 1880,
                            StartDate = 1879
                        },
                        new
                        {
                            Nth = "47th",
                            EndDate = 1882,
                            StartDate = 1881
                        },
                        new
                        {
                            Nth = "48th",
                            EndDate = 1884,
                            StartDate = 1883
                        },
                        new
                        {
                            Nth = "49th",
                            EndDate = 1886,
                            StartDate = 1885
                        },
                        new
                        {
                            Nth = "50th",
                            EndDate = 1888,
                            StartDate = 1887
                        },
                        new
                        {
                            Nth = "51st",
                            EndDate = 1890,
                            StartDate = 1889
                        },
                        new
                        {
                            Nth = "52nd",
                            EndDate = 1892,
                            StartDate = 1891
                        },
                        new
                        {
                            Nth = "53rd",
                            EndDate = 1894,
                            StartDate = 1893
                        },
                        new
                        {
                            Nth = "54th",
                            EndDate = 1896,
                            StartDate = 1895
                        },
                        new
                        {
                            Nth = "55th",
                            EndDate = 1898,
                            StartDate = 1897
                        },
                        new
                        {
                            Nth = "56th",
                            EndDate = 1900,
                            StartDate = 1899
                        },
                        new
                        {
                            Nth = "57th",
                            EndDate = 1902,
                            StartDate = 1901
                        },
                        new
                        {
                            Nth = "58th",
                            EndDate = 1904,
                            StartDate = 1903
                        },
                        new
                        {
                            Nth = "59th",
                            EndDate = 1906,
                            StartDate = 1905
                        },
                        new
                        {
                            Nth = "60th",
                            EndDate = 1908,
                            StartDate = 1907
                        },
                        new
                        {
                            Nth = "61st",
                            EndDate = 1910,
                            StartDate = 1909
                        },
                        new
                        {
                            Nth = "62nd",
                            EndDate = 1912,
                            StartDate = 1911
                        },
                        new
                        {
                            Nth = "63rd",
                            EndDate = 1914,
                            StartDate = 1913
                        },
                        new
                        {
                            Nth = "64th",
                            EndDate = 1916,
                            StartDate = 1915
                        },
                        new
                        {
                            Nth = "65th",
                            EndDate = 1918,
                            StartDate = 1917
                        },
                        new
                        {
                            Nth = "66th",
                            EndDate = 1920,
                            StartDate = 1919
                        },
                        new
                        {
                            Nth = "67th",
                            EndDate = 1922,
                            StartDate = 1921
                        },
                        new
                        {
                            Nth = "68th",
                            EndDate = 1924,
                            StartDate = 1923
                        },
                        new
                        {
                            Nth = "69th",
                            EndDate = 1926,
                            StartDate = 1925
                        },
                        new
                        {
                            Nth = "70th",
                            EndDate = 1928,
                            StartDate = 1927
                        },
                        new
                        {
                            Nth = "71st",
                            EndDate = 1930,
                            StartDate = 1929
                        },
                        new
                        {
                            Nth = "72nd",
                            EndDate = 1932,
                            StartDate = 1931
                        },
                        new
                        {
                            Nth = "73rd",
                            EndDate = 1934,
                            StartDate = 1933
                        },
                        new
                        {
                            Nth = "74th",
                            EndDate = 1936,
                            StartDate = 1935
                        },
                        new
                        {
                            Nth = "75th",
                            EndDate = 1938,
                            StartDate = 1937
                        },
                        new
                        {
                            Nth = "76th",
                            EndDate = 1940,
                            StartDate = 1939
                        },
                        new
                        {
                            Nth = "77th",
                            EndDate = 1942,
                            StartDate = 1941
                        },
                        new
                        {
                            Nth = "78th",
                            EndDate = 1944,
                            StartDate = 1943
                        },
                        new
                        {
                            Nth = "79th",
                            EndDate = 1946,
                            StartDate = 1945
                        },
                        new
                        {
                            Nth = "80th",
                            EndDate = 1948,
                            StartDate = 1947
                        },
                        new
                        {
                            Nth = "81st",
                            EndDate = 1950,
                            StartDate = 1949
                        },
                        new
                        {
                            Nth = "82nd",
                            EndDate = 1952,
                            StartDate = 1951
                        },
                        new
                        {
                            Nth = "83rd",
                            EndDate = 1954,
                            StartDate = 1953
                        },
                        new
                        {
                            Nth = "84th",
                            EndDate = 1956,
                            StartDate = 1955
                        },
                        new
                        {
                            Nth = "85th",
                            EndDate = 1958,
                            StartDate = 1957
                        },
                        new
                        {
                            Nth = "86th",
                            EndDate = 1960,
                            StartDate = 1959
                        },
                        new
                        {
                            Nth = "87th",
                            EndDate = 1962,
                            StartDate = 1961
                        },
                        new
                        {
                            Nth = "88th",
                            EndDate = 1964,
                            StartDate = 1963
                        },
                        new
                        {
                            Nth = "89th",
                            EndDate = 1966,
                            StartDate = 1965
                        },
                        new
                        {
                            Nth = "90th",
                            EndDate = 1968,
                            StartDate = 1967
                        },
                        new
                        {
                            Nth = "91st",
                            EndDate = 1970,
                            StartDate = 1969
                        },
                        new
                        {
                            Nth = "92nd",
                            EndDate = 1972,
                            StartDate = 1971
                        },
                        new
                        {
                            Nth = "93rd",
                            EndDate = 1974,
                            StartDate = 1973
                        },
                        new
                        {
                            Nth = "94th",
                            EndDate = 1976,
                            StartDate = 1975
                        },
                        new
                        {
                            Nth = "95th",
                            EndDate = 1978,
                            StartDate = 1977
                        },
                        new
                        {
                            Nth = "96th",
                            EndDate = 1980,
                            StartDate = 1979
                        },
                        new
                        {
                            Nth = "97th",
                            EndDate = 1982,
                            StartDate = 1981
                        },
                        new
                        {
                            Nth = "98th",
                            EndDate = 1984,
                            StartDate = 1983
                        },
                        new
                        {
                            Nth = "99th",
                            EndDate = 1986,
                            StartDate = 1985
                        },
                        new
                        {
                            Nth = "100th",
                            EndDate = 1988,
                            StartDate = 1987
                        },
                        new
                        {
                            Nth = "101st",
                            EndDate = 1990,
                            StartDate = 1989
                        },
                        new
                        {
                            Nth = "102nd",
                            EndDate = 1992,
                            StartDate = 1991
                        },
                        new
                        {
                            Nth = "103rd",
                            EndDate = 1994,
                            StartDate = 1993
                        },
                        new
                        {
                            Nth = "104th",
                            EndDate = 1996,
                            StartDate = 1995
                        },
                        new
                        {
                            Nth = "105th",
                            EndDate = 1998,
                            StartDate = 1997
                        },
                        new
                        {
                            Nth = "106th",
                            EndDate = 2000,
                            StartDate = 1999
                        },
                        new
                        {
                            Nth = "107th",
                            EndDate = 2002,
                            StartDate = 2001
                        },
                        new
                        {
                            Nth = "108th",
                            EndDate = 2004,
                            StartDate = 2003
                        },
                        new
                        {
                            Nth = "109th",
                            EndDate = 2006,
                            StartDate = 2005
                        },
                        new
                        {
                            Nth = "110th",
                            EndDate = 2008,
                            StartDate = 2007
                        },
                        new
                        {
                            Nth = "111th",
                            EndDate = 2010,
                            StartDate = 2009
                        },
                        new
                        {
                            Nth = "112th",
                            EndDate = 2012,
                            StartDate = 2011
                        },
                        new
                        {
                            Nth = "113th",
                            EndDate = 2014,
                            StartDate = 2013
                        },
                        new
                        {
                            Nth = "114th",
                            EndDate = 2016,
                            StartDate = 2015
                        },
                        new
                        {
                            Nth = "115th",
                            EndDate = 2018,
                            StartDate = 2017
                        },
                        new
                        {
                            Nth = "116th",
                            EndDate = 2020,
                            StartDate = 2019
                        },
                        new
                        {
                            Nth = "117th",
                            EndDate = 2022,
                            StartDate = 2021
                        },
                        new
                        {
                            Nth = "118th",
                            EndDate = 2024,
                            StartDate = 2023
                        });
                });

            modelBuilder.Entity("InspireUs.Congress.Domain.Model.Legislation", b =>
                {
                    b.HasOne("InspireUs.Congress.Domain.Model.UsCongress", "Congress")
                        .WithMany("Legislations")
                        .HasForeignKey("CongressNth")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InspireUs.Congress.Domain.Model.Member", "SponserMember")
                        .WithMany("Legislations")
                        .HasForeignKey("SponserMemberId");

                    b.Navigation("Congress");

                    b.Navigation("SponserMember");
                });

            modelBuilder.Entity("InspireUs.Congress.Domain.Model.Member", b =>
                {
                    b.OwnsOne("InspireUs.Congress.Domain.Model.Address", "Address", b1 =>
                        {
                            b1.Property<string>("MemberId")
                                .HasColumnType("nvarchar(10)");

                            b1.Property<string>("Address1")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Address1");

                            b1.Property<string>("Address2")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Address2");

                            b1.Property<string>("City")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("AddressCity");

                            b1.Property<int?>("State")
                                .HasColumnType("int")
                                .HasColumnName("AddressState");

                            b1.Property<string>("ZipCode")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("AddressZipCode");

                            b1.HasKey("MemberId");

                            b1.ToTable("Member");

                            b1.WithOwner()
                                .HasForeignKey("MemberId");
                        });

                    b.OwnsOne("InspireUs.Congress.Domain.Model.District", "District", b1 =>
                        {
                            b1.Property<string>("MemberId")
                                .HasColumnType("nvarchar(10)");

                            b1.Property<int?>("DistrictNumber")
                                .HasColumnType("int")
                                .HasColumnName("DistrictRepresented");

                            b1.Property<int>("State")
                                .HasColumnType("int")
                                .HasColumnName("StateRepresented");

                            b1.HasKey("MemberId");

                            b1.ToTable("Member");

                            b1.WithOwner()
                                .HasForeignKey("MemberId");
                        });

                    b.OwnsMany("InspireUs.Congress.Domain.Model.ServiceTime", "ServiceHistory", b1 =>
                        {
                            b1.Property<string>("MemberId")
                                .HasColumnType("nvarchar(10)");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<int?>("EndYear")
                                .HasColumnType("int");

                            b1.Property<int>("MemberType")
                                .HasColumnType("int");

                            b1.Property<int>("StartYear")
                                .HasColumnType("int");

                            b1.HasKey("MemberId", "Id");

                            b1.ToTable("ServiceTime");

                            b1.WithOwner()
                                .HasForeignKey("MemberId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("District")
                        .IsRequired();

                    b.Navigation("ServiceHistory");
                });

            modelBuilder.Entity("InspireUs.Congress.Domain.Model.Member", b =>
                {
                    b.Navigation("Legislations");
                });

            modelBuilder.Entity("InspireUs.Congress.Domain.Model.UsCongress", b =>
                {
                    b.Navigation("Legislations");
                });
#pragma warning restore 612, 618
        }
    }
}
