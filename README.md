<div align="center">
  
# SJSU VR Lab
  
Cognitive Effects of Embodied Learning with Virtual Reality Laboratory Environments for Engineering ( VRLEs)

![VRlab 95f9c992f155785c9f94](https://user-images.githubusercontent.com/38381290/199352505-c72681df-b7b1-4a67-8700-f613e88a4b90.gif)
  
</div>
  
## Introduction
CVRLabSJSU allows students to simulate tensile testing of specimen materials, interactive diagrams demonstrating Poisson's ratio, and provides a way to quiz them based on the lab experimentations. This laboratory is being used to research the effects of "embodied cognition" described in Markansky et. al, 2020, through an A/B split test.

## How to run in a Meta Quest 2
1. Download the apk's in this repository. If you wish to use the embodied version of the lab, use `VRlab_A`, otherwise use `VRlab_B`.
2. Sideload the apk to your Meta Quest 2 using a Usb-C cable using a tool such as SideQuest https://sidequestvr.com
3. Run the application. Keep in mind, the current builds will 

## How to edit and build using Unity Engine
1. Clone the repository
2. Open the `VRlab` folder using Unity Desktop. The latest Unity version should work, although the project was developed with `Unity 2022.2.18f1 , macOS Silicon`.
3. Make any customizations as necessary
4. Switch the build to Android, Build and Run with your Oculus Quest 2 headset connected. More information: https://developer.oculus.com/documentation/unity/unity-build/


## Code Architecture
All project files are stored in the `Assets` folder within the Unity project, and the general architecture is the following:
- `

## Acknowledgements
CVRLabSJSU is brought to you by the VR/AR/CV Lab at San José State University.

## Credits:

### Technical Lead
Rafael Padilla Perez

### Project Advisor
Ozgur Keles, Ph.D

This project is a new repository. which includes some 3D meshes from CVRLabSJSU project by Vincent Brubaker-Gianakos https://github.com/Apelsin/CVRLabSJSU, which is a fork from the CVRLabSJSU project by Ian Hunter, which is in turn a fork of the SBHacks project by Connor Smith, Anish Kannan, and Kristin Agcaoili.

Hand models and rig provided under creative commons 4.0 license: https://developer.oculus.com/licenses/creative-commons-4.0

</div>
