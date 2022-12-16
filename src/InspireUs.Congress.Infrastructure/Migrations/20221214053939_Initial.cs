using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InspireUs.Congress.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DistrictRepresented = table.Column<int>(type: "int", nullable: true),
                    StateRepresented = table.Column<int>(type: "int", nullable: false),
                    Party = table.Column<int>(type: "int", nullable: false),
                    MemberType = table.Column<int>(type: "int", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddressCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddressState = table.Column<int>(type: "int", nullable: true),
                    AddressZipCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsCongress",
                columns: table => new
                {
                    Nth = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    StartDate = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsCongress", x => x.Nth);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTime",
                columns: table => new
                {
                    MemberId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberType = table.Column<int>(type: "int", nullable: false),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    EndYear = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTime", x => new { x.MemberId, x.Id });
                    table.ForeignKey(
                        name: "FK_ServiceTime_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Legislation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BillNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroducedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CongressNth = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    SponserMemberId = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legislation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Legislation_Member_SponserMemberId",
                        column: x => x.SponserMemberId,
                        principalTable: "Member",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Legislation_UsCongress_CongressNth",
                        column: x => x.CongressNth,
                        principalTable: "UsCongress",
                        principalColumn: "Nth",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UsCongress",
                columns: new[] { "Nth", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { "100th", 1988, 1987 },
                    { "101st", 1990, 1989 },
                    { "102nd", 1992, 1991 },
                    { "103rd", 1994, 1993 },
                    { "104th", 1996, 1995 },
                    { "105th", 1998, 1997 },
                    { "106th", 2000, 1999 },
                    { "107th", 2002, 2001 },
                    { "108th", 2004, 2003 },
                    { "109th", 2006, 2005 },
                    { "10th", 1808, 1807 },
                    { "110th", 2008, 2007 },
                    { "111th", 2010, 2009 },
                    { "112th", 2012, 2011 },
                    { "113th", 2014, 2013 },
                    { "114th", 2016, 2015 },
                    { "115th", 2018, 2017 },
                    { "116th", 2020, 2019 },
                    { "117th", 2022, 2021 },
                    { "118th", 2024, 2023 },
                    { "11th", 1810, 1809 },
                    { "12th", 1812, 1811 },
                    { "13th", 1814, 1813 },
                    { "14th", 1816, 1815 },
                    { "15th", 1818, 1817 },
                    { "16th", 1820, 1819 },
                    { "17th", 1822, 1821 },
                    { "18th", 1824, 1823 },
                    { "19th", 1826, 1825 },
                    { "1st", 1790, 1789 },
                    { "20th", 1828, 1827 },
                    { "21st", 1830, 1829 },
                    { "22nd", 1832, 1831 },
                    { "23rd", 1834, 1833 },
                    { "24th", 1836, 1835 },
                    { "25th", 1838, 1837 },
                    { "26th", 1840, 1839 },
                    { "27th", 1842, 1841 },
                    { "28th", 1844, 1843 },
                    { "29th", 1846, 1845 },
                    { "2nd", 1792, 1791 },
                    { "30th", 1848, 1847 },
                    { "31st", 1850, 1849 },
                    { "32nd", 1852, 1851 },
                    { "33rd", 1854, 1853 },
                    { "34th", 1856, 1855 },
                    { "35th", 1858, 1857 },
                    { "36th", 1860, 1859 },
                    { "37th", 1862, 1861 },
                    { "38th", 1864, 1863 },
                    { "39th", 1866, 1865 },
                    { "3rd", 1794, 1793 },
                    { "40th", 1868, 1867 },
                    { "41st", 1870, 1869 },
                    { "42nd", 1872, 1871 },
                    { "43rd", 1874, 1873 },
                    { "44th", 1876, 1875 },
                    { "45th", 1878, 1877 },
                    { "46th", 1880, 1879 },
                    { "47th", 1882, 1881 },
                    { "48th", 1884, 1883 },
                    { "49th", 1886, 1885 },
                    { "4th", 1796, 1795 },
                    { "50th", 1888, 1887 },
                    { "51st", 1890, 1889 },
                    { "52nd", 1892, 1891 },
                    { "53rd", 1894, 1893 },
                    { "54th", 1896, 1895 },
                    { "55th", 1898, 1897 },
                    { "56th", 1900, 1899 },
                    { "57th", 1902, 1901 },
                    { "58th", 1904, 1903 },
                    { "59th", 1906, 1905 },
                    { "5th", 1798, 1797 },
                    { "60th", 1908, 1907 },
                    { "61st", 1910, 1909 },
                    { "62nd", 1912, 1911 },
                    { "63rd", 1914, 1913 },
                    { "64th", 1916, 1915 },
                    { "65th", 1918, 1917 },
                    { "66th", 1920, 1919 },
                    { "67th", 1922, 1921 },
                    { "68th", 1924, 1923 },
                    { "69th", 1926, 1925 },
                    { "6th", 1800, 1799 },
                    { "70th", 1928, 1927 },
                    { "71st", 1930, 1929 },
                    { "72nd", 1932, 1931 },
                    { "73rd", 1934, 1933 },
                    { "74th", 1936, 1935 },
                    { "75th", 1938, 1937 },
                    { "76th", 1940, 1939 },
                    { "77th", 1942, 1941 },
                    { "78th", 1944, 1943 },
                    { "79th", 1946, 1945 },
                    { "7th", 1802, 1801 },
                    { "80th", 1948, 1947 },
                    { "81st", 1950, 1949 },
                    { "82nd", 1952, 1951 },
                    { "83rd", 1954, 1953 },
                    { "84th", 1956, 1955 },
                    { "85th", 1958, 1957 },
                    { "86th", 1960, 1959 },
                    { "87th", 1962, 1961 },
                    { "88th", 1964, 1963 },
                    { "89th", 1966, 1965 },
                    { "8th", 1804, 1803 },
                    { "90th", 1968, 1967 },
                    { "91st", 1970, 1969 },
                    { "92nd", 1972, 1971 },
                    { "93rd", 1974, 1973 },
                    { "94th", 1976, 1975 },
                    { "95th", 1978, 1977 },
                    { "96th", 1980, 1979 },
                    { "97th", 1982, 1981 },
                    { "98th", 1984, 1983 },
                    { "99th", 1986, 1985 },
                    { "9th", 1806, 1805 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Legislation_CongressNth",
                table: "Legislation",
                column: "CongressNth");

            migrationBuilder.CreateIndex(
                name: "IX_Legislation_SponserMemberId",
                table: "Legislation",
                column: "SponserMemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Legislation");

            migrationBuilder.DropTable(
                name: "ServiceTime");

            migrationBuilder.DropTable(
                name: "UsCongress");

            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
