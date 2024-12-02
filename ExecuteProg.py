#Ce code vérifie si C# (via le .NET SDK) est installé sur un système Windows ou Linux.
#Si C# n'est pas installé, le script tentera de l'installer en fonction du système d'exploitation détecté

import subprocess
import sys
import os

def check_dotnet_installed():
    try:
        result = subprocess.run(['dotnet', '--version'], capture_output=True, text=True)
        if result.returncode == 0:
            print(f".NET SDK est installé, version: {result.stdout.strip()}")
            return True
        else:
            return False
    except FileNotFoundError:
        return False

def install_dotnet_windows():
    """Installe .NET SDK sur Windows si nécessaire."""
    print("C# n'est pas installé. Installation de .NET SDK sur Windows...")
    url = "https://aka.ms/dotnet-sdk-installer"
    subprocess.run(['start', url], shell=True)

def install_dotnet_linux():
    """Installe .NET SDK sur Linux si nécessaire."""
    print("C# n'est pas installé. Installation de .NET SDK sur Linux...")
    dist_name = subprocess.run(['lsb_release', '-i', '-s'], capture_output=True, text=True).stdout.strip().lower()

    if dist_name == "ubuntu" or dist_name == "debian":
        subprocess.run(['sudo', 'apt-get', 'install', 'apt-transport-https', '-y'])
        subprocess.run(['wget', 'https://packages.microsoft.com/config/ubuntu/20.04/prod.list', '-O', '/etc/apt/sources.list.d/dotnetdev.list'])
        subprocess.run(['sudo', 'apt-get', 'update'])
        subprocess.run(['sudo', 'apt-get', 'install', 'dotnet-sdk-7.0', '-y'])
    elif dist_name == "fedora":
        subprocess.run(['sudo', 'dnf', 'install', 'dotnet-sdk-7.0', '-y'])
    else:
        print(f"Système Linux non pris en charge: {dist_name}")
        sys.exit(1)

def set_permissions_linux(file_path):
    """Attribue les permissions d'exécution au fichier sur Linux."""
    print(f"Attribution des permissions d'exécution à {file_path}...")
    subprocess.run(['chmod', '+x', file_path])

def run_script(file_path):
    """Lance un script (compilprogramme.sh ou équivalent)."""
    if not os.path.isfile(file_path):
        print(f"Le fichier {file_path} n'existe pas !")
        sys.exit(1)

    if sys.platform.startswith('linux'):
        set_permissions_linux(file_path)

    print(f"Lancement du script {file_path}...")
    
    if sys.platform.startswith('win'):
        if file_path.endswith('.bat'):
            subprocess.run([file_path], shell=True)
        else:
            print("Le script Windows doit être un fichier batch (.bat) ou PowerShell (.ps1).")
            sys.exit(1)
    else:
        subprocess.run(['bash', file_path])

def main():
    if check_dotnet_installed():
        print("C# est déjà installé sur ce système.")
    else:
        if sys.platform.startswith('win'):
            install_dotnet_windows()
        elif sys.platform.startswith('linux'):
            install_dotnet_linux()
        else:
            print("Système d'exploitation non pris en charge. Ce script fonctionne sur Windows et Linux.")
            sys.exit(1)

    if sys.platform.startswith('win'):
        script_path = '.\compile\compilprogramme.bat'
    else:
        script_path = './compile/compilprogramme.sh'

    run_script(script_path)

if __name__ == "__main__":
    main()
