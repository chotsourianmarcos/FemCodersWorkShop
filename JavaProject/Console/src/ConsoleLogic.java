import JavaProject.Entities.SuperCharacter;
import JavaProject.Entities.SuperPower;
import JavaProject.Entities.UltraSuperPower;
import JavaProject.Logic.SuperCharacterLogic.ISuperCharacterLogic;
import JavaProject.Logic.SuperPowerLogic.ISuperPowerLogic;
import java.io.IOException;
import javax.xml.bind.ValidationException;
import java.io.BufferedReader;

public class ConsoleLogic implements IConsoleLogic{

    private BufferedReader _reader;
    private ISuperCharacterLogic _superCharacterLogic;
    private ISuperPowerLogic _superPowerLogic;

    public ConsoleLogic(BufferedReader reader, ISuperCharacterLogic superCharacterLogic, ISuperPowerLogic superPowerLogic){
        _reader = reader;
        _superCharacterLogic = superCharacterLogic;
        _superPowerLogic = superPowerLogic;
    }

    public SuperCharacter CreateSuperCharacter() throws Exception{

        System.out.println("Inserte el nombre secreto del nuevo personaje:");
        String secretName = _reader.readLine();

        SuperCharacter superCharacter = new SuperCharacter(secretName);
        
        System.out.println("Inserte el nombre conocido del nuevo personaje:");
        superCharacter.PublicName = _reader.readLine();
        
        System.out.println("Inserte \"Mar\" si o \"Montania\" para definir el alineamiento de " + superCharacter.PublicName + ":");
        String readLine = _reader.readLine();

        if(readLine.equals("Mar")){
            superCharacter.Alignment = true;
        }else if(readLine.equals("Montania")){
            superCharacter.Alignment = false;
        }else{
            superCharacter.Alignment = null;
        }

        readLine = "0";
        do{
            System.out.println("Inserte 1 para crear un UltraSuperPoder o 2 para crear dos SuperPoderes para " + superCharacter.PublicName + ":");
            readLine = _reader.readLine();
        }while(readLine.equals("1") && readLine.equals("2"));

        if(readLine.equals("1")){
            superCharacter.ultraSuperPower = new UltraSuperPower(CreateSuperPower());
        }else{
            superCharacter.SuperPowers.add(CreateSuperPower());
            superCharacter.SuperPowers.add(CreateSuperPower());
        }

        superCharacter.SetInitialStamina();

        if(!_superCharacterLogic.ValidateSuperCharacter(superCharacter)){
            throw new ValidationException("Ups...");
        };

        return superCharacter;
        
    }

    public SuperPower CreateSuperPower() throws Exception{

        SuperPower superPower = new SuperPower();

        System.out.println("Inserte el nombre del nuevo SuperPoder:");
        superPower.Name = _reader.readLine();

        System.out.println("Inserte la descripción del nuevo SuperPoder:");
        superPower.Description = _reader.readLine();
        
        System.out.println("Inserte un valor del 1 al 10 para establecer la fuerza del nuevo SuperPoder:");
        superPower.Strength = Integer.parseInt(_reader.readLine());
        superPower.Cost = superPower.Strength;

        if(!_superPowerLogic.ValidateSuperPower(superPower)){
            throw new ValidationException("Ups...");
        };

        return superPower;

    }

    public void PrintMainMenu(){

        System.out.println("\n1. Crear Super Personaje.");
        System.out.println("2. Listar Super Personajes.");
        System.out.println("3. Calcular Alineamiento predominante.");
        System.out.println("4. Calcular Fuerza promedio.");
        System.out.println("5. Fin.\n");

    }

    public int ChooseMenuOption() throws IOException{

        PrintMainMenu();
        return Integer.parseInt(_reader.readLine());
        
    }
}
