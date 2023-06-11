int participantes=0;
int tiros=0;
//pedir datos 
obtenerParametros(ref participantes,ref tiros);
//definir tamaño de arrays
string [] nombreParticipantes = new string[participantes];
int [] puntajeParticipantes = new int [participantes];
// pedir nombres
pedirNombres(ref nombreParticipantes);


for(int i=0;i<participantes;i++){
    Console.WriteLine("###########################################");
    Console.WriteLine($"Preparate para jugar {nombreParticipantes[i]}");
    int[,] resultadosParciales = new int [2,3]; // 0 :pc , 1:jugador
    int sumPuntos=0;
    for(int j=0;j<tiros;j++){
        //eleccion jugador
        int eleccionJugador = procesarEleccion(j);
        //eleccion pc 
        int eleccionPC = randomPC();
        mostrarEleccion(eleccionPC);
        int valor = obtenerPuntaje(eleccionPC, eleccionJugador);
        sumPuntos += valor;
        if(valor == 0){
            //empate
            resultadosParciales[1,1] +=1;
            resultadosParciales[0,1] +=1;
        }else if(valor<0){
            //perdido
            resultadosParciales[1,2] +=1;
            resultadosParciales[0,0] +=1;
        }else{
            //ganado
            resultadosParciales[1,0] +=1;
            resultadosParciales[0,2] +=1;

        }
        Console.WriteLine("----------------------");
        Console.WriteLine($"g:{resultadosParciales[1,0]} e:{resultadosParciales[1,1]} p:{resultadosParciales[1,2]} ");
        Console.WriteLine($"tu puntos obtenidos: {valor}");
    }
    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine($"Resultado de la partida del jugador {nombreParticipantes[i]}:");
    if (resultadosParciales[0,0]> resultadosParciales[1,0]){
        Console.WriteLine("Partida Perdida");
    }else if(resultadosParciales[0,0] == resultadosParciales[1,0]) {
        Console.WriteLine("Partida Empatada");
    }else{
        Console.WriteLine("Partida Ganada");
    }
    Console.WriteLine($"tu puntaje Total es: {sumPuntos}");
    puntajeParticipantes[i]=sumPuntos;
    Console.WriteLine("----------------------------------------------------");
}
Console.WriteLine("##### resultados finales ########");
//orden de lista
Array.Sort(puntajeParticipantes,nombreParticipantes);
Array.Reverse(nombreParticipantes);
Array.Reverse(puntajeParticipantes);
Console.WriteLine("### Tabla de Posiciones ###");
for(int i =0; i<participantes;i++){
    Console.WriteLine($"{i+1}° puesto {nombreParticipantes[i]} tu resultado es {puntajeParticipantes[i]}");
}
Console.WriteLine("### Ganador  ###");
Console.WriteLine($"Participante {nombreParticipantes[0]} su puntaje es {puntajeParticipantes[0]}");


//####### funciones ######################
static void mostrarEleccion(int eleccion){
    switch(eleccion){
        case 1: Console.WriteLine("PC: Papel");
        break; 
        case 2: Console.WriteLine("PC: Piedra");
        break;
        case 3: Console.WriteLine("PC: Tijera");
        break;
    }
}
static int randomPC(){
    Random rnd = new Random();
        return rnd.Next(1,4);
}
static int obtenerPuntaje(int eleccionPC,int eleccionJugador){
    if (eleccionJugador == eleccionPC){
        Console.WriteLine("empate");
        return 0;
    }else if(eleccionJugador == 3 && eleccionPC == 1 ){
        Console.WriteLine("ganaste");
        return 2;
    }else if(eleccionJugador == 1 && eleccionPC == 3 ){
        Console.WriteLine("perdiste");
        return -1;
    }else if(eleccionJugador<eleccionPC){
        Console.WriteLine("ganaste");
        return 2;
    }else{
        Console.WriteLine("perdiste");
        return -1;
    }
}
static int procesarEleccion(int tiro){
    Console.WriteLine($"**************");
    Console.WriteLine($"Tiro numero: {tiro+1}");
    Console.WriteLine("Escribe la letra correspondiente  p -> Papel, r -> Piedra, t-> Tijera");
    string eleccion = Console.ReadLine().ToLower();
    while(eleccion != "p" && eleccion != "r" && eleccion != "t"){
        Console.WriteLine("Error a ingresar");
        Console.WriteLine($"Tiro numero: {tiro+1}");
        Console.WriteLine("Escribe la letra correspondiente  p -> Papel, r -> Piedra, t-> Tijera");
        eleccion = Console.ReadLine().ToLower();
    }
    int result = 0;
    switch(eleccion){
        case "p": Console.WriteLine("TU: Papel"); 
                    result = 1;
        break; 
        case "r": Console.WriteLine("TU: Piedra");
                    result = 2; 
        break;
        case "t": Console.WriteLine("TU: Tijera");
                    result = 3; 
        break;
    }
    
    return result;
}
static void pedirNombres(ref string [] nombreParticipantes){
    for(int i =0;i<nombreParticipantes.Length;i++){
        Console.WriteLine($"ingresa nombre del partipantes nro : {i+1} ");
        nombreParticipantes[i]=Console.ReadLine();
    }
   
}
static void obtenerParametros( ref int participantes ,ref int tiros){
Console.WriteLine("JUEGO CLASICO");
Console.WriteLine("ingrese cantidad de participantes");
participantes= Convert.ToInt16(Console.ReadLine()); 
Console.WriteLine("ingrese cantidad de tiros , max:10");
tiros= Convert.ToInt16(Console.ReadLine());
while(tiros > 10 || tiros <0){
    Console.WriteLine("se excedio, vuelva a ingresar la cantidad de tiros, max:10");
    tiros= Convert.ToInt16(Console.ReadLine());
} 
}



