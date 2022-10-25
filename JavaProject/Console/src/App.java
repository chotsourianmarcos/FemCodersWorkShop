import JavaProject.Entities.SuperCharacter;
import JavaProject.Logic.SuperCharacterLogic.SuperCharacterLogic;
import JavaProject.Logic.SuperPowerLogic.SuperPowerLogic;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;

public class App {

    public static void main(String[] args) throws Exception {

        //ver si hay alguna manera de establecer las definiciones de las interfaces distinto...como en C#
        IConsoleLogic consoleLogic = new ConsoleLogic(
            new BufferedReader(new InputStreamReader(System.in)),
            new SuperCharacterLogic(),
            new SuperPowerLogic()
        );
        
        ArrayList<SuperCharacter> superCharacters = new ArrayList<SuperCharacter>();

        int option = 0;
        option = consoleLogic.ChooseMenuOption();

        while(option != 5)
        switch(option){

            case 1:
            superCharacters.add(consoleLogic.CreateSuperCharacter());
            System.out.println("¡" + superCharacters.get(superCharacters.size() - 1).PublicName + "se ha unido al equipo!");
            option = consoleLogic.ChooseMenuOption();
            break;

            case 2:
            if(superCharacters.size() == 0){
                System.out.println("No hay nadie por aquí aún (?)...");
            }else{
                for(SuperCharacter sp:superCharacters){
                    System.out.println(sp.PublicName);
                };
            }
            option = consoleLogic.ChooseMenuOption();
            break;

            case 3:
            int countSea = 0;
            int countMountain = 0;
            for(SuperCharacter sp:superCharacters){
                if(sp.Alignment == null){
                    continue;
                }
                if(sp.Alignment == true){
                    countSea++;
                }else{
                    countMountain++;
                }
            };
            if(countSea > countMountain){
                System.out.println("Predomina team Mar!");
            }else if(countSea < countMountain){
                System.out.println("Predomina team Montaña!");
            }else{
                System.out.println("El cosmos está en equilibrio.");
            }
            option = consoleLogic.ChooseMenuOption();
            break;

            case 4:
            if(superCharacters.size() == 0){
                System.out.println("No hay nadie por aquí aún (?)...");
            }else{
                int fuerzaTotal = 0;
                for(SuperCharacter sp:superCharacters){
                    fuerzaTotal += sp.GetStamina();
                };
                System.out.println("La fuerza promedio es: " + fuerzaTotal / superCharacters.size());
            }
            option = consoleLogic.ChooseMenuOption();
            break;

            default:
            System.out.println("Ingrese un valor adecuado, por favor : )");
            option = consoleLogic.ChooseMenuOption();
            break;

        }
        
        System.out.println("Hasta luego!");

    }

}
