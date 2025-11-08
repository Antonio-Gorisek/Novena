# Novena

**Novena** is a test task made a few years ago for a temporary job. The project was created in a very short time (2 days) and represents the basic implementation of the audio player and display of media content.
<p align="center" style="display:flex; gap:2px; justify-content:center;">
  <img src="https://github.com/user-attachments/assets/507f4696-f045-4568-9eaa-aec3abb6f7e2" width="33%" />
  <img src="https://github.com/user-attachments/assets/1e7c830e-ac4f-474d-a521-a4632929d1b3" width="32%" />
  <img src="https://github.com/user-attachments/assets/5081bf77-fd61-48fc-9641-7b91fe20158e" width="33.35%" />
</p>


## Project description

- Plays audio tracks that are defined in JSON files.
- Displays images related to topics from JSON and switches them automatically.
- Contains a simple design and basic UI functionality.
- All elements (audio, images and texts) are loaded via Unity `Resources` folder and json file.

## Project scripts

- `JsonManager.cs` – loads data from JSON files and provides methods for retrieving topics, media and audio files. 
- `AudioManager.cs` – controls audio playback, UI slider and play/pause functionality. 
- `PlayPageData.cs` – displays the title and page number, and changes images related to the selected topic. 
- `LoadContent.cs` – dynamically creates UI elements for all themes and adds listeners to buttons.
- `MenuManager.cs` – controls the navigation between the main list and the content display page.

## Note

The project was made minimally, exclusively for the demonstration of basic functionalities. The design and interactions are as simple as the code.
