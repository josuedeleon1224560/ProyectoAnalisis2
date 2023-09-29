﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class datos_Tabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
    table: "Tabla_Departamentos",
    columns: new[] { "Nombre" },
    values: new object[,]
    {
                    {"Alta Verapaz"},
                    {"Baja Verapaz"},
                    {"Chimaltenango" },
                    {"Chiquimula" },
                    {"El Progreso" },
                    {"Escuintla" },
                    {"Departamento de Guatemala" },
                    {"Huehuetenango" },
                    {"Izabal" },
                    {"Jalapa" },
                    {"Jutiapa" },
                    {"Peten" },
                    {"Quetzaltenango" },
                    {"Quiché" },
                    {"Retalhuleu" },
                    {"Sacatepéquez" },
                    {"San Marcos" },
                    {"Santa Rosa" },
                    {"Sololá" },
                    {"Suchitepéquez" },
                    {"Totonicapán" },
                    {"Zacapa" }
    });

            migrationBuilder.InsertData(
                table: "Tabla_Municipios",
                columns: new[] { "Nombre", "DepartamentoId" },
                values: new object[,]
                {
                    {"Chahal", "1"},
                    {"Chisec", "1"},
                    {"Cobán", "1"},
                    {"Fray Bartolomé de las Casas", "1"},
                    {"La Tinta", "1"},
                    {"Lanquín", "1"},
                    {"Panzós", "1"},
                    {"Raxruhá", "1"},
                    {"San Cristóbal Verapaz", "1"},
                    {"San Juan Chamelco", "1"},
                    {"San Pedro Carchá", "1"},
                    {"Santa Cruz Verapaz", "1"},
                    {"Santa María Cahabón", "1"},
                    {"Senahú", "1"},
                    {"Tactic", "1"},
                    {"Tamahú", "1"},
                    {"Tucurú", "1"},


                    {"Cubulco", "2"},
                    {"Santa Cruz el Chol", "2"},
                    {"Granados", "2"},
                    {"Purulhá", "2"},
                    {"Rabinal", "2"},
                    {"Salamá", "2"},
                    {"San Miguel Chicaj", "2"},
                    {"San Jerónimo", "2"},


                    {"Chimaltenango", "3"},
                    {"San José Poaquíl", "3"},
                    {"San Martín Jilotepeque", "3"},
                    {"San Juan Comalapa", "3"},
                    {"Santa Apolonia", "3"},
                    {"Tecpán Guatemala", "3"},
                    {"Patzún", "3"},
                    {"Pochuta", "3"},
                    {"Patzicía", "3"},
                    {"Santa Cruz Balanyá", "3"},
                    {"Acatenango", "3"},
                    {"San Pedro Yepocapa", "3"},
                    {"San Andrés Itzapa", "3"},
                    {"Parramos", "3"},
                    {"Zaragoza", "3"},
                    {"El Tejar", "3"},


                    {"Chiquimula", "4"},
                    {"Jocotán", "4"},
                    {"Camotán", "4"},
                    {"Esquipulas", "4"},
                    {"Quetzaltepeque", "4"},
                    {"Olopa", "4"},
                    {"Ipala", "4"},
                    {"San Juan Ermita", "4"},
                    {"San Jacinto", "4"},
                    {"Concepción Las Minas", "4"},
                    {"San José La Arada", "4"},


                    {"El Jícaro", "5"},
                    {"Guastatoya", "5"},
                    {"Morazán", "5"},
                    {"Sanarate", "5"},
                    {"Sansare", "5"},
                    {"San Agustín Acasaguastlán", "5"},
                    {"San Antonio La Paz", "5"},
                    {"San Cristóbal Acasaguastlán", "5"},


                    {"Escuintla (Cabecera Departamental)", "6"},
                    {"Guanagazapa", "6"},
                    {"Iztapa", "6"},
                    {"La Democracia", "6"},
                    {"La Gomera", "6"},
                    {"Masagua", "6"},
                    {"Nueva Concepción", "6"},
                    {"Palín", "6"},
                    {"San José", "6"},
                    {"San Vicente Pacaya", "6"},
                    {"Santa Lucía Cotzumalguapa", "6"},
                    {"Sipacate", "6"},
                    {"Siquinalá", "6"},
                    {"Tiquisate", "6"},


                    {"Guatemala", "7"},
                    {"Villa Nueva", "7"},
                    {"Mixco", "7"},
                    {"Santa Catarina Pinula", "7"},
                    {"San José Pinula", "7"},
                    {"San José del Golfo", "7"},
                    {"Palencia", "7"},
                    {"Chinautla", "7"},
                    {"San Pedro Ayampuc", "7"},
                    {"San Pedro Sacatepéquez", "7"},
                    {"San Juan Sacatepéquez", "7"},
                    {"San Raymundo", "7"},
                    {"Chuarrancho", "7"},
                    {"Fraijanes", "7"},
                    {"Amatitlán", "7"},
                    {"Villa Canales", "7"},
                    {"San Miguel Petapa", "7"},


                    {"Huehuetenango", "8"},
                    {"Santa Cruz Barillas", "8"},
                    {"Chiantla", "8"},
                    {"Cuilco", "8"},
                    {"La Democracia", "8"},
                    {"Aguacatán", "8"},
                    {"San Pedro Soloma", "8"},
                    {"Nentón", "8"},
                    {"San Ildefonso Ixtahuacán", "8"},
                    {"San Mateo Ixtatán", "8"},
                    {"Santa Eulalia", "8"},
                    {"San Pedro Necta", "8"},
                    {"La Libertad", "8"},
                    {"Jacaltenango", "8"},
                    {"Colotenango", "8"},
                    {"Santa Bárbara", "8"},
                    {"San Sebastián Huehuetenango", "8"},
                    {"Todos Santos Cuchumatán", "8"},
                    {"San Miguel Acatán", "8"},
                    {"San Juan Ixcoy", "8"},
                    {"San Sebastián Coatán", "8"},
                    {"San Juan Atitlán", "8"},
                    {"Malacatancito", "8"},
                    {"Concepción Huista", "8"},
                    {"San Antonio Huista", "8"},
                    {"Unión Cantinil", "8"},
                    {"San Rafael La Independencia", "8"},
                    {"San Rafael Pétzal", "8"},
                    {"Tectitán", "8"},
                    {"Santiago Chimaltenango", "8"},
                    {"Santa Ana Huista", "8"},
                    {"San Gaspar Ixchil", "8"},
                    {"Petatán", "8"},


                    {"Puerto Barrios", "9"},
                    {"Livingston", "9"},
                    {"El Estor", "9"},
                    {"Morales", "9"},
                    {"Los Amates", "9"},


                    {"Agua Blanca", "10"},
                    {"Asunción Mita", "10"},
                    {"Atescatempa", "10"},
                    {"Comapa", "10"},
                    {"Conguaco", "10"},
                    {"El Adelanto", "10"},
                    {"El Progreso", "10"},
                    {"Jalpatagua", "10"},
                    {"Jerez", "10"},
                    {"Jutiapa", "10"},
                    {"Moyuta", "10"},
                    {"Pasaco", "10"},
                    {"Quesada", "10"},
                    {"San José Acatempa", "10"},
                    {"Santa Catarina Mita", "10"},
                    {"Yupiltepeque", "10"},
                    {"Zapotitlán", "10"},


                    {"Dolores", "11"},
                    {"Flores", "11"},
                    {"La Libertad", "11"},
                    {"Melchor de Mencos", "11"},
                    {"Poptún", "11"},
                    {"San Andrés", "11"},
                    {"San Benito", "11"},
                    {"San Francisco", "11"},
                    {"San José", "11"},
                    {"San Luis", "11"},
                    {"Santa Ana", "11"},
                    {"Sayaxché", "11"},
                    {"Las Cruces", "11"},
                    {"El Chal", "11"},


                    {"Almolonga", "12"},
                    {"Cabricán", "12"},
                    {"Cajolá", "12"},
                    {"Cantel", "12"},
                    {"Coatepeque", "12"},
                    {"Colomba", "12"},
                    {"Concepción Chiquirichapa", "12"},
                    {"El Palmar", "12"},
                    {"Flores Costa Cuca", "12"},
                    {"Génova", "12"},
                    {"Huitán", "12"},
                    {"La Esperanza", "12"},
                    {"Olintepeque", "12"},
                    {"Palestina de Los Altos", "12"},
                    {"Quetzaltenango", "12"},
                    {"Salcajá", "12"},
                    {"San Carlos Sija", "12"},
                    {"San Juan Ostuncalco", "12"},
                    {"San Francisco La Unión", "12"},
                    {"San Martín Sacatepéquez", "12"},
                    {"San Mateo", "12"},
                    {"San Miguel Sigüilá", "12"},
                    {"Sibilia", "12"},
                    {"Zunil", "12"},


                    {"Pachalum", "13"},
                    {"Santa Cruz del Quiché", "13"},
                    {"Chinique", "13"},
                    {"Nebaj", "13"},
                    {"Cunén", "13"},
                    {"Ixcán", "13"},
                    {"San Juan Cotzal", "13"},
                    {"Chichicastenango", "13"},
                    {"Canillá", "13"},
                    {"Sacapulas", "13"},
                    {"Patzité", "13"},
                    {"Uspantán", "13"},
                    {"Chiché", "13"},
                    {"San Antonio Ilotenango", "13"},
                    {"Chicamán", "13"},
                    {"Chajul", "13"},
                    {"San Andrés Sajcabajá", "13"},
                    {"Zacualpa", "13"},
                    {"Joyabaj", "13"},
                    {"San Bartolomé Jocotenango", "13"},
                    {"San Pedro Jocopilas", "13"},


                    {"Retalhuleu (cabecera)", "14"},
                    {"San Sebastián", "14"},
                    {"Santa Cruz Muluá", "14"},
                    {"San Martín Zapotitlán", "14"},
                    {"San Felipe", "14"},
                    {"San Andrés Villa Seca", "14"},
                    {"Champerico", "14"},
                    {"Nuevo San Carlos", "14"},
                    {"El Asintal", "14"},


                    {"Alotenango", "15"},
                    {"Antigua Guatemala", "15"},
                    {"Ciudad Vieja", "15"},
                    {"Jocotenango", "15"},
                    {"Magdalena Milpas Altas", "15"},
                    {"Pastores", "15"},
                    {"San Antonio Aguas Calientes", "15"},
                    {"San Bartolomé Milpas Altas", "15"},
                    {"San Lucas Sacatepéquez", "15"},
                    {"San Miguel Dueñas", "15"},
                    {"Santa Catarina Barahona", "15"},
                    {"Santa Lucía Milpas Altas", "15"},
                    {"Santa María de Jesús", "15"},
                    {"Santiago Sacatepéquez", "15"},
                    {"Santo Domingo Xenacoj", "15"},
                    {"Sumpango", "15"},



                    {"San Marcos (San Marcos)", "16"},
                    {"Ayutla", "16"},
                    {"Catarina", "16"},
                    {"Comitancillo", "16"},
                    {"Concepción Tutuapa", "16"},
                    {"El Quetzal", "16"},
                    {"El Rodeo", "16"},
                    {"El Tumbador", "16"},
                    {"Ixchiguán", "16"},
                    {"La Reforma", "16"},
                    {"Malacatán", "16"},
                    {"Nuevo Progreso", "16"},
                    {"Ocós", "16"},
                    {"Pajapita", "16"},
                    {"Esquipulas Palo Gordo", "16"},
                    {"San Antonio Sacatepéquez", "16"},
                    {"San Cristóbal Cucho", "16"},
                    {"San José Ojetenam", "16"},
                    {"San Lorenzo", "16"},
                    {"San Miguel Ixtahuacán", "16"},
                    {"San Pablo", "16"},
                    {"San Pedro Sacatepéquez", "16"},
                    {"San Rafael Pie de la Cuesta", "16"},
                    {"Sibinal", "16"},
                    {"Sipacapa", "16"},
                    {"Tacaná", "16"},
                    {"Tajumulco", "16"},
                    {"Tejutla", "16"},
                    {"Río Blanco", "16"},
                    {"La Blanca", "16"},


                    {"Barberena", "17"},
                    {"Casillas", "17"},
                    {"Chiquimulilla", "17"},
                    {"Cuilapa", "17"},
                    {"Guazacapán", "17"},
                    {"Monterrico", "17"},
                    {"Nueva Santa Rosa", "17"},
                    {"Oratorio", "17"},
                    {"Pueblo Nuevo Viñas", "17"},
                    {"San Juan Tecuaco", "17"},
                    {"San Rafael Las Flores", "17"},
                    {"Santa Cruz Naranjo", "17"},
                    {"Santa María Ixhuatán", "17"},
                    {"Santa Rosa de Lima", "17"},
                    {"Taxisco", "17"},


                    {"Sololá", "18"},
                    {"Concepción", "18"},
                    {"Nahualá", "18"},
                    {"Panajachel", "18"},
                    {"San Andrés Semetabaj", "18"},
                    {"San Antonio Palopó", "18"},
                    {"San José Chacayá", "18"},
                    {"San Juan La Laguna", "18"},
                    {"San Lucas Tolimán", "18"},
                    {"San Marcos La Laguna", "18"},
                    {"San Pablo La Laguna", "18"},
                    {"San Pedro La Laguna", "18"},
                    {"Santa Catarina Ixtahuacán", "18"},
                    {"Santa Catarina Palopó", "18"},
                    {"Santa Clara La Laguna", "18"},
                    {"Santa Cruz La Laguna", "18"},
                    {"Santa Lucía Utatlán", "18"},
                    {"Santa María Visitación", "18"},
                    {"Santiago Atitlán", "18"},


                    {"Chicacao", "19"},
                    {"Cuyotenango", "19"},
                    {"Mazatenango", "19"},
                    {"Patulul", "19"},
                    {"Pueblo Nuevo", "19"},
                    {"Río Bravo", "19"},
                    {"Samayac", "19"},
                    {"San Antonio Suchitepéquez", "19"},
                    {"San Bernardino", "19"},
                    {"San Francisco Zapotitlán", "19"},
                    {"San Gabriel", "19"},
                    {"San José El Ídolo", "19"},
                    {"San José La Máquina", "19"},
                    {"San Juan Bautista", "19"},
                    {"San Lorenzo", "19"},
                    {"San Miguel Panán", "19"},
                    {"San Pablo Jocopilas", "19"},
                    {"Santa Bárbara", "19"},
                    {"Santo Domingo Suchitepéquez", "19"},
                    {"Santo Tomás La Unión", "19"},
                    {"Zunilito", "19"},


                    {"Momostenango", "20"},
                    {"San Andrés Xecul", "20"},
                    {"San Bartolo", "20"},
                    {"San Cristóbal Totonicapán", "20"},
                    {"San Francisco El Alto", "20"},
                    {"Santa Lucía La Reforma", "20"},
                    {"Santa María Chiquimula", "20"},
                    {"Totonicapán", "20"},


                    {"Cabañas", "21"},
                    {"Estanzuela", "21"},
                    {"Gualán", "21"},
                    {"Huité", "21"},
                    {"La Unión", "21"},
                    {"Río Hondo", "21"},
                    {"San Diego", "21"},
                    {"San Jorge24", "21"},
                    {"Teculután", "21"},
                    {"Usumatlán", "21"},
                    {"Zacapa", "21"}
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
