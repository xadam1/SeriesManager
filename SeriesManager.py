import os
import shutil
import time
from typing import List
import re
from typing import Dict, Any
import tkinter as tk
from tkinter import filedialog


def get_dir_path_from_user() -> str or None:
    root = tk.Tk()
    root.withdraw()

    popup_msg("Please enter directory with your series.")

    file_path = filedialog.askdirectory(title="Choose Series Directory")
    root.destroy()

    root.mainloop()

    return file_path if os.path.isdir(file_path) else None


def get_ep_names_file_path_from_user() -> str or None:
    root = tk.Tk()
    root.withdraw()

    #popup_msg("Please enter file with episode names.")
    file_path = filedialog.askopenfilename(title="Select A File", filetypes=[('Text Files', '*.txt')])
    root.destroy()

    return file_path if os.path.isfile(file_path) else None


def popup_msg(msg):
    popup = tk.Tk()
    popup.wm_title("Info!")
    label = tk.Label(popup, text=msg, font=("Verdana", 10))
    label.pack(side="top", fill="x", pady=10)
    btn = tk.Button(popup, text="Okay", command=popup.destroy)
    btn.pack()
    popup.destroy()


def get_episodes_from_dir(ep_dir_path: str) -> Dict[str, Any]:
    print(f"Moving to {ep_dir_path}...\n")

    count = 0
    files_to_process = {}
    for file in os.listdir(ep_dir_path):
        filepath = os.path.join(ep_dir_path, file)

        if os.path.isfile(filepath):
            count += 1
            files_to_process[file] = filepath

    print(f"FILES FOUND: {count}...\n")
    return files_to_process


def extract_ep_names_from_file(filepath: str) -> List[str] or None:
    with open(filepath) as f:
        content = f.readlines()

    episodes = []
    for line in content:
        line.strip()
        if not line.startswith('S'):
            continue

        # EXAMPLE S02 E10 · Valar Morghulis
        tmp = line.split('·', 1)
        ep, name = tmp[0], tmp[1]
        # ^ SIMPLY FOR PYCHARM LINTING... ^
        ep = ep.replace(' ', '')
        name = name.replace(' ', '_')

        fullname = f"{ep.upper()}-{name}"
        episodes.append(fullname)

    return episodes


def process_files(files: Dict[str, Any], series_dir: str) -> bool or None:
    print("Starting serialization...\n")
    count = 0
    for file in files:
        print('\r', end='')
        print(f"FILES PROCESSED: {count}\t\tNow processing: {file}", end='')

        filename, extension = file.rsplit('.', 1)

        ep_label = re.match(r'.*([Ss]\d+[Ee]\d+).*', filename).group(1)
        ep_label = ep_label.upper()

        episode_dir = os.path.join(series_dir, ep_label)

        ep_name = f"{ep_label}.{extension}"
        ep_path = os.path.join(series_dir, ep_name)
        os.rename(files[file], ep_name)

        files[file] = ep_path

        os.mkdir(episode_dir)

        # files[file] contains path to the file
        shutil.move(files[file], episode_dir)

        count += 1

        # TODO REMOVE
        time.sleep(3)

    print('\r', end='')
    print(f"Serialization DONE! Files processed: {count}\n")


def run_manager() -> None:
    series_dir = get_dir_path_from_user()
    if series_dir is None:
        print("Invalid path to SERIES FOLDER!")
        raise Exception("Invalid path!")

    ep_names_file = get_ep_names_file_path_from_user()
    if ep_names_file is None:
        print("Invalid path to EP NAMES FILE!")
        raise Exception("Invalid path!")

    ep_names = extract_ep_names_from_file(ep_names_file)
    print(ep_names)

    # just to be sure absolute path
    os.chdir(series_dir)
    series_dir = os.getcwd()

    files = get_episodes_from_dir(series_dir)
    process_files(files, series_dir)

    print("Everything DONE!")


if __name__ == '__main__':
    run_manager()
