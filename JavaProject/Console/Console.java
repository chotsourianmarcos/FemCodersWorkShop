package JavaProject.Console;
import JavaProject.Entities.SuperCharacter;
import java.util.List;

import org.omg.PortableInterceptor.AdapterStateHelper;
 
class Console {
    public static void main(String[] args)
    {
        List<SuperCharacter> superCharacters = new List<SuperCharacter>();

        var option = 0;
        option = ChooseMenuOption();

        while(option != 5)
        switch(option){
            case 1:
            superCharacters.Add(CreateSuperHero());
            option = ChooseMenuOption();
            break;
            case 2:
            for(SuperCharacter sp:superCharacters){
                System.out.println(sp.PublicName);
            };
            option = ChooseMenuOption();
            break;
            case 3:
            int countGood = 0;
            int countEvil = 0;
            for(SuperCharacter sp:superCharacters){
                if(sp.Alignment == true){
                    countGood++;
                }else{
                    countEvil--;
                }
            };
            if(countGood > countEvil){
                System.out.println("Predominan las Super Heroínas!");
            }else if(countGood < countEvil){
                System.out.println("Predominan las Super Villanas!");
            }else{
                System.out.println("El cosmos está en equilibrio.");
            }
            option = ChooseMenuOption();
            break;
            case 4:
            int fuerzaTotal = 0;
            for(SuperCharacter sp:superCharacters){
                fuerzaTotal += sp.GetStamina();
            };
            System.out.println(fuerzaTotal / superCharacters.Count);
            option = ChooseMenuOption();
            break;
            default:
            superCharacters.Add(CreateSuperHero());
            break;
        }
            

        

    }

    private static int ChooseMenuOption(){
        PrintMainMenu();
        return reader.readLine();
    }
    
}
