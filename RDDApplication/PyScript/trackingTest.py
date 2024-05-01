# -*- coding: utf8 -*-

import cv2
from ultralytics import YOLO


# Load the YOLOv8 model
model = YOLO("C:\\Users\\User\\source\\repos\\RDDApplication\\RDDApplication\\PyScript\\best.pt")

# Open the video file
video_path = "C:\\Users\\User\\source\\repos\\RDDApplication\\RDDApplication\\Video\\cracksVideo.mp4"
cap = cv2.VideoCapture(video_path)
FramesSkipped = 1


# Loop through the video frames
while cap.isOpened():
    # Read a frame from the video
    for i in range(FramesSkipped):
        bSuccess = cap.grab()
    success, frame = cap.read()
    frame = cv2.resize(frame, (1280, 720))
    if success:
        # Run YOLOv8 tracking on the frame, persisting tracks between frames
        results = model.track(frame, persist=True, conf = 0.65)
        print(results[0])
        # Visualize the results on the frame
        annotated_frame = results[0].plot()

        # Display the annotated frame
        cv2.imshow("YOLOv8 Tracking", annotated_frame)

        # Break the loop if 'q' is pressed
        if cv2.waitKey(24) & 0xFF == ord("q"):
            break
    else:
        # Break the loop if the end of the video is reached
        break

# Release the video capture object and close the display window
cap.release()
cv2.destroyAllWindows()