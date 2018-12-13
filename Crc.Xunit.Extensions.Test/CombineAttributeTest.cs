using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit.Extensions;

namespace Crc.Xunit.Extensions.Test
{
    public enum Enum1
    {
        Enum1_1,
        Enum1_2,
        Enum1_3,
    }

    public enum Enum2
    {
        Enum2_1,
        Enum2_2
    }

    public enum Enum3
    {
        Enum3_1,
        Enum3_2
    }

    public class CombineAttributeTest
    {
        [XFact]
        public void Cuando_le_paso_una_lista_de_enums_entonces_los_combina()
        {
            CombineAttribute attribute = new CombineAttribute(typeof(Enum1), typeof(Enum2), typeof(Enum3));
            IEnumerable<object[]> datosEsperados = new List<object[]>
            {
                new object[] {Enum1.Enum1_1, Enum2.Enum2_1, Enum3.Enum3_1},
                new object[] {Enum1.Enum1_1, Enum2.Enum2_1, Enum3.Enum3_2},
                new object[] {Enum1.Enum1_1, Enum2.Enum2_2, Enum3.Enum3_1},
                new object[] {Enum1.Enum1_1, Enum2.Enum2_2, Enum3.Enum3_2},
                new object[] {Enum1.Enum1_2, Enum2.Enum2_1, Enum3.Enum3_1},
                new object[] {Enum1.Enum1_2, Enum2.Enum2_1, Enum3.Enum3_2},    
                new object[] {Enum1.Enum1_2, Enum2.Enum2_2, Enum3.Enum3_1},
                new object[] {Enum1.Enum1_2, Enum2.Enum2_2, Enum3.Enum3_2},
                new object[] {Enum1.Enum1_3, Enum2.Enum2_1, Enum3.Enum3_1},
                new object[] {Enum1.Enum1_3, Enum2.Enum2_1, Enum3.Enum3_2},
                new object[] {Enum1.Enum1_3, Enum2.Enum2_2, Enum3.Enum3_1},
                new object[] {Enum1.Enum1_3, Enum2.Enum2_2, Enum3.Enum3_2},
            };

           IEnumerable<object[]> datosObtenidos = attribute.GetData(null);

            datosObtenidos.ShouldBeEquivalentTo(datosEsperados);
        }

        [XFact]
        public void Cuando_combino_booleanos_con_enums_y_listas_entonces_los_combina()
        {
            CombineAttribute attribute = new CombineAttribute(typeof(bool), typeof(Enum2), new List<int> { 5,6 });
            IEnumerable<object[]> datosEsperados = new List<object[]>
            {
                new object[] {false, Enum2.Enum2_1, 5},
                new object[] {false, Enum2.Enum2_1, 6},
                new object[] {false, Enum2.Enum2_2, 5},
                new object[] {false, Enum2.Enum2_2, 6},
                new object[] {true, Enum2.Enum2_1, 5},
                new object[] {true, Enum2.Enum2_1, 6}, 
                new object[] {true, Enum2.Enum2_2, 5},
                new object[] {true, Enum2.Enum2_2, 6},
            };

            IEnumerable<object[]> datosObtenidos = attribute.GetData(null);

            datosObtenidos.ShouldBeEquivalentTo(datosEsperados);
        }

        [XFact]
        public void Cuando_le_paso_algo_que_no_es_enum_ni_bool_ni_enumerable_entonces_lanza_excepcion()
        {
            Action crearAtributo = () => new CombineAttribute(88, typeof(Enum2), new List<int> { 5, 6 });

            crearAtributo.ShouldThrow<ArgumentException>();
        }

        [XTheory]
        [Combine(typeof(Enum1), typeof(Enum3), typeof(bool))]
        public void Prueba(Enum1 valorEnum, Enum3 enum3 , bool valorBooleano)
        {
            valorBooleano.Should().Be(valorBooleano);
            valorEnum.Should().Be(valorEnum);
            enum3.Should().Be(enum3);
        }

        [XTheory]
        [Combine(typeof(Enum1),new[] {1,2,3}, typeof(bool))]
        public void Prueba_con_array(Enum1 valorEnum, Enum3 enum3, bool valorBooleano)
        {
            valorBooleano.Should().Be(valorBooleano);
            valorEnum.Should().Be(valorEnum);
            enum3.Should().Be(enum3);
        }
    }
}
